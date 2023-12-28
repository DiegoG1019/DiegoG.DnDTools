using System.Diagnostics;
using System.Xml;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.InventoryManager.Measures;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Common.Responses.Views;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.EntityFramework.Repositories.Base;
using DiegoG.DnDTools.Services.Utilities;
using DiegoG.DnDTools.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiegoG.DnDTools.Services.EntityFramework.Repositories;

public class EntityFrameworkInventoryRepository(DnDToolsContext context, IDnDToolsCharacterRepository charrepo, IServiceProvider services)
    : EntityFrameworkCRUDRepository<InventoryModel, InventoryCreationModel, InventoryUpdateModel>(context), IInventoryRepository
{
    protected readonly IServiceProvider Services = services;
    protected readonly IDnDToolsCharacterRepository CharacterRepository = charrepo;

    public override async ValueTask<SuccessResult<object>?> UpdateEntity(DnDToolsUser? requester, Guid key, InventoryUpdateModel updateModel)
    {
        ErrorList err = new();
        var t = GetEditableEntities(requester);
        if (t is null)
        {
            err.AddNoPermission();
            return err;
        }

        var entity = await t.Where(x => x.Id == key).FirstOrDefaultAsync();
        if (entity is null)
        {
            err.AddEntityNotFound(nameof(InventoryModel), $"id:{key}");
            return err;
        }

        if (ModelManipulationHelper.IsUpdatingString(entity.Name, updateModel.Name))
            entity.Name = updateModel.Name;

        if (ModelManipulationHelper.IsUpdatingString(entity.Description, updateModel.Description))
            entity.Description = updateModel.Description;

        if (ModelManipulationHelper.IsUpdatingString(entity.Notes, updateModel.Notes))
            entity.Notes = updateModel.Notes;

        if (updateModel.Tags is not null)
        {
            var tagset = entity.Tags?.ToHashSet(CaseInsensitiveStringComparer.Instance) ?? [];
            updateModel.Tags.PerformActionsString(tagset, ref err);

            if (err.Count > 0)
                return new(err);

            entity.Tags = tagset;
        }

        return entity;
    }

    public override async ValueTask<SuccessResult<InventoryModel>> CreateEntity(DnDToolsUser? requester, InventoryCreationModel creationModel)
    {
        ErrorList errors = new();
        var characters = CharacterRepository.GetEditableEntities(requester);
        if (requester is null || characters is null) 
        {
            errors.AddNoPermission();
            return errors;
        }

        errors.IsEmptyString(creationModel.Name);

        if (await Context.Characters.AnyAsync(x => x.Id == creationModel.OwnerCharacterId) is false)
            errors.AddEntityNotFound(nameof(DnDToolsCharacter), $"id:{creationModel.OwnerCharacterId}");

        if (creationModel.ContainerItemId is Guid cid && await characters
                .Where(x => x.Inventories != null)
                .SelectMany(x => x.Inventories!)
                .Where(x => x.Items != null)
                .SelectMany(x => x.Items!)
                .AnyAsync(x => x.Id == cid) is false)
            errors.AddEntityNotFound(nameof(ItemDescription), $"id:{cid}");

        if (errors.Count > 0)
            return errors;

        Debug.Assert(creationModel.Name is not null);

        var inv = new InventoryModel()
        {
            Id = Guid.NewGuid(),
            Name = creationModel.Name,
            Tags = creationModel.Tags?.ToHashSet(CaseInsensitiveStringComparer.Instance),
            CharacterId = creationModel.OwnerCharacterId,
            MaximumItems = creationModel.MaximumItems,
            Description = creationModel.Description,
            Notes = creationModel.Notes,
            ContainerItemId = creationModel.ContainerItemId
        };

        Context.Inventories.Add(inv);
        
        return inv;
    }

    public override IQueryable<InventoryModel>? GetEntities(DnDToolsUser? requester) 
        => CharacterRepository.GetEntities(requester)?
                               .Where(x => x.Inventories != null)
                               .SelectMany(x => x.Inventories!);

    public IQueryable<InventoryModel>? GetEntities(DnDToolsUser? requester, Guid characterId)
        => CharacterRepository.GetEntities(requester)?
                               .Where(x => x.Id == characterId && x.Inventories != null)
                               .SelectMany(x => x.Inventories!);

    public IQueryable<InventoryModel>? GetEntities(DnDToolsUser? requester, DnDToolsCharacter character)
        => GetEntities(requester, character.Id);

    public IQueryable<InventoryModel>? GetEditableEntities(DnDToolsUser? requester)
        => CharacterRepository.GetEditableEntities(requester)?
                               .Where(x => x.Inventories != null)
                               .SelectMany(x => x.Inventories!);

    public IQueryable<InventoryModel>? GetEditableEntities(DnDToolsUser? requester, Guid characterId)
        => CharacterRepository.GetEditableEntities(requester)?
                               .Where(x => x.Id == characterId && x.Inventories != null)
                               .SelectMany(x => x.Inventories!);

    public IQueryable<InventoryModel>? GetEditableEntities(DnDToolsUser? requester, DnDToolsCharacter character)
        => GetEditableEntities(requester, character.Id);

    public override async ValueTask<SuccessResult<object>> GetView(DnDToolsUser? requester, InventoryModel entity)
        => new DnDToolsInventoryView()
        {
            Id = entity.Id,
            Description = entity.Description,
            ItemCount = await GetInventoryItemCount(entity),
            Items = await ExpandInventory(entity),
            Name = entity.Name,
            Notes = entity.Notes,
            Tags = entity.Tags,
            OwnerId = entity.CharacterId,
            Owner = await ExpandOwner(entity)
        };

    public override IQueryable<object>? GetViews(DnDToolsUser? requester, IQueryable<InventoryModel> entities)
        => entities.Select(x => new DnDToolsInventoryView()
        {
            Id = x.Id,
            Description = x.Description,
            ItemCount = x.Items.Count,
            Items = x.Items.Select(d => new EmbeddedItemDescriptionView()
            {
                ContainerId = d.ContainerInventoryId,
                Id = d.Id,
                Name = d.Name,
                EntityType = d.EntityType,
                BasePrice = d.BasePriceCopper.HasValue && d.BasePriceSilver.HasValue && d.BasePriceElectron.HasValue && d.BasePriceGold.HasValue && d.BasePricePlatinum.HasValue
                    ? new(d.BasePriceCopper.Value, d.BasePriceSilver.Value, d.BasePriceElectron.Value, d.BasePriceGold.Value, d.BasePricePlatinum.Value)
                    : null,
                Size = d.SizeValue.HasValue && d.SizeUnit.HasValue 
                        ? new(d.SizeValue.Value, d.SizeUnit.Value, 3)
                        : null,
                Amount = d.AmountValue.HasValue && d.AmountUnit.HasValue
                        ? new(d.AmountValue.Value, d.AmountUnit.Value)
                        : null,
                WeightPerItem = d.WeightPerItemValue.HasValue && d.WeightPerItemUnit.HasValue
                        ? new(d.WeightPerItemValue.Value, d.WeightPerItemUnit.Value)
                        : null,
            }),
            Name = x.Name,
            Notes = x.Notes,
            Tags = x.Tags,
            OwnerId = x.CharacterId,
            Owner = new DnDToolsEmbeddedCharacterView()
            {
                Id = x.Character!.Id,
                Name = x.Character!.Name,
                OwnerId = x.Character!.OwnerId,
                ReferenceImageUrl = x.Character!.ReferenceImageUrl
            }
        });

    protected async ValueTask<DnDToolsEmbeddedCharacterView> ExpandOwner(InventoryModel inventoryModel)
        => inventoryModel.Character is not null
            ? new DnDToolsEmbeddedCharacterView()
            {
                Id = inventoryModel.Character.Id,
                Name = inventoryModel.Character.Name,
                OwnerId = inventoryModel.Character.OwnerId,
                ReferenceImageUrl = inventoryModel.Character.ReferenceImageUrl
            }
            : await Context.Characters.Where(x => x.Id == inventoryModel.CharacterId)
                                      .Select(x => new DnDToolsEmbeddedCharacterView()
                                      {
                                          Id = x.Id,
                                          Name = x.Name,
                                          OwnerId = x.OwnerId,
                                          ReferenceImageUrl = x.ReferenceImageUrl
                                      })
                                      .FirstAsync();

    protected async ValueTask<int> GetInventoryItemCount(InventoryModel inventoryModel)
        => inventoryModel.Items?.Count
            ?? await Context.Inventories.Where(x => x.Id == inventoryModel.Id && x.Items != null)
                                        .SelectMany(x => x.Items)
                                        .CountAsync();

    protected async ValueTask<IEnumerable<EmbeddedItemDescriptionView>> ExpandInventory(InventoryModel inventoryModel)
        => inventoryModel.Items?.Count > 0
            ? inventoryModel.Items.Select(x => new EmbeddedItemDescriptionView()
            {
                Id = x.Id,
                ContainerId = x.ContainerInventoryId,
                Name = x.Name,
                EntityType = x.EntityType,
                BasePrice = ((ItemDescription)x).BasePrice,
                Size = ((ItemDescription)x).Size,
                Amount = ((ItemDescription)x).Amount,
                WeightPerItem = ((ItemDescription)x).WeightPerItem,
            })
            : await Context.Inventories
                           .Where(x => x.Id == inventoryModel.Id)
                           .SelectMany(x => x.Items)
                           .Select(x => new EmbeddedItemDescriptionView()
                           {
                               Id = x.Id,
                               ContainerId = x.ContainerInventoryId,
                               Name = x.Name,
                               EntityType = ((ItemDescription)x).EntityType,
                               BasePrice = ((ItemDescription)x).BasePrice,
                               Size = ((ItemDescription)x).Size,
                               WeightPerItem = ((ItemDescription)x).WeightPerItem,
                               Amount = ((ItemDescription)x).Amount
                           })
                           .ToListAsync();

    private ValueTask<int> DeleteOwnedItems(DnDToolsUser user, Guid inventory)
    {
        var charrepo = Services.GetRequiredService<IItemDescriptionRepository>();
        return charrepo.DeleteEntities(user, Context.Inventories.Where(x => x.Id == inventory).SelectMany(x => x.Items));
    }

    private ValueTask<int> DeleteOwnedItems(DnDToolsUser requester, IEnumerable<Guid> inventories)
    {
        var charrepo = Services.GetRequiredService<IItemDescriptionRepository>();
        return charrepo.DeleteEntities(requester, Context.Inventories.Where(x => inventories.Contains(x.Id)).SelectMany(x => x.Items));
    }

    public override async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<InventoryModel> entities)
    {
        if (requester is null) return -1;
        await DeleteOwnedItems(requester, entities.Select(x => x.Id));
        return await base.DeleteEntities(requester, entities);
    }

    public override async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<Guid> ids)
    {
        if (requester is null) return -1;
        await DeleteOwnedItems(requester, ids);
        return await base.DeleteEntities(requester, ids);
    }

    public override async ValueTask<SuccessResult> DeleteEntity(DnDToolsUser? requester, InventoryModel entity)
    {
        if (requester is null)
        {
            ErrorList errors = new();
            errors.AddNoPermission();
            return errors;
        }

        await DeleteOwnedItems(requester, entity.Id);
        return await base.DeleteEntity(requester, entity);
    }

    public override async ValueTask<SuccessResult?> DeleteEntity(DnDToolsUser? requester, Guid id)
    {
        if (requester is null)
        {
            ErrorList errors = new();
            errors.AddNoPermission();
            return errors;
        }

        await DeleteOwnedItems(requester, id);
        return await base.DeleteEntity(requester, id);
    }
}
