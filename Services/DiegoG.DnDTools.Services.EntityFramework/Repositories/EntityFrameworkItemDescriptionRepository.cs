using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
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
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DiegoG.DnDTools.Services.EntityFramework.Repositories;

public class EntityFrameworkItemDescriptionRepository(DnDToolsContext context, IDnDToolsCharacterRepository charrepo)
    : EntityFrameworkCRUDRepository<IBaseItemDescriptionModel, ItemDescriptionCreationModel, ItemDescriptionUpdateModel>(context), IItemDescriptionRepository
{
    protected readonly IDnDToolsCharacterRepository CharacterRepository = charrepo;
    private IItemDescriptionRepository ThisAsRepo => this;
    // The analyzer will say that changing this to a less derived type will improve performance, that's cuz calls through an interface are always virtual
    // Which aren't slow, but also aren't as fast as a direct call because they involve less jumps and lookups in asm (IL, in this case)
    // Anyway, the methods we're calling through this property (And the reason it exists) don't exist in this type, so they're inaccessible unless called like this

    public override IQueryable<IBaseItemDescriptionModel>? GetEntities(DnDToolsUser? requester)
    {
        if (requester is null)
            return null;

        return CharacterRepository
                      .GetEntities(requester)
                     ?.Where(x => x.Inventories != null)
                      .SelectMany(x => x.Inventories!)
                      .SelectMany(x => x.Items);
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesInInventory(DnDToolsUser? requester, Guid inventoryId)
    {
        if (requester is null)
            return null;

        return CharacterRepository
                      .GetEntities(requester)
                     ?.Where(x => x.Inventories != null)
                      .SelectMany(x => x.Inventories!)
                      .Where(x => x.Id == inventoryId)
                      .SelectMany(x => x.Items);
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesInInventory(DnDToolsUser? requester, InventoryModel inventory)
        => GetEntitiesInInventory(requester, (inventory ?? throw new ArgumentNullException(nameof(inventory))).Id);

    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesFromCharacter(DnDToolsUser? requester, Guid characterId)
    {
        if (requester is null)
            return null;

        return CharacterRepository
                      .GetEntities(requester)
                     ?.Where(x => x.Id == characterId)
                      .Where(x => x.Inventories != null)
                      .SelectMany(x => x.Inventories!)
                      .SelectMany(x => x.Items);
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesFromCharacter(DnDToolsUser? requester, DnDToolsCharacter character)
        => GetEntitiesFromCharacter(requester, character.Id);

    public override async ValueTask<SuccessResult<object>?> UpdateEntity(DnDToolsUser? requester, Guid key, ItemDescriptionUpdateModel updateModel)
    {
        var characters = CharacterRepository.GetEditableEntities(requester);
        if (requester is null || characters is null) return null;
        ErrorList er = default;

        var entity = await GetEntities(requester)!.Where(x => x.Id == key).FirstOrDefaultAsync();
        if (entity is null) return null;

        if (updateModel.Inventory is Guid newinv)
        {
            if (await characters.Where(x => x.Inventories != null)
                                .SelectMany(x => x.Inventories!)
                                .AnyAsync(x => x.Id == newinv))
                entity.ContainerInventoryId = newinv;
            else
                er.AddEntityNotFound("Inventory", $"id:{newinv}");
        }

        var item = (ItemDescription)entity;
        
        if (er.Count > 0 is false)
        {
            if (updateModel.BasePrice is UpdateNullableStruct<Money> basePrice)
                item.BasePrice = basePrice.Value;
        
            if (updateModel.Size is UpdateNullableStruct<Area> size)
                item.Size = size.Value;
        
            if (updateModel.Weight is UpdateNullableStruct<Mass> weight)
                item.WeightPerItem = weight.Value;
        
            if (updateModel.Amount is UpdateNullableStruct<Quantity> amount)
                item.Amount = amount.Value;
        } 

        if (updateModel.Tags is not null)
        {
            var tagset = item.Tags?.ToHashSet(CaseInsensitiveStringComparer.Instance) ?? new HashSet<string>(CaseInsensitiveStringComparer.Instance);
            updateModel.Tags.PerformActionsString(
                tagset,
                ref er
            );
            item.Tags = tagset;
        }

        if (er.Count > 0) return er;

        if (ModelManipulationHelper.IsUpdating(item.Notes, updateModel.Notes))
            item.Notes = updateModel.Notes;

        if (ModelManipulationHelper.IsUpdating(item.Description, updateModel.Description))
            item.Description = updateModel.Description;

        if (ModelManipulationHelper.IsUpdating(item.Name, updateModel.Name))
            item.Name = updateModel.Name;

        if (entity is WeaponItemDescription weapon)
        {
            if (ModelManipulationHelper.IsUpdating(weapon.WeaponCategory, updateModel.WeaponCategory))
                weapon.WeaponCategory = updateModel.WeaponCategory;
            
            if (ModelManipulationHelper.IsUpdating(weapon.DamageType, updateModel.DamageType))
                weapon.DamageType = updateModel.DamageType;
            
            if (ModelManipulationHelper.IsUpdating(weapon.Range, updateModel.Range))
                weapon.Range = updateModel.Range;
            
            if (ModelManipulationHelper.IsUpdating(weapon.ThrownRange, updateModel.ThrownRange))
                weapon.ThrownRange = updateModel.ThrownRange;
            
            if (ModelManipulationHelper.IsUpdating(weapon.DamageThrow, updateModel.DamageThrow))
                weapon.DamageThrow = updateModel.DamageThrow;
            
            if (ModelManipulationHelper.IsUpdating(weapon.GraspType, updateModel.GraspType))
                weapon.GraspType = updateModel.GraspType;
            
            if (ModelManipulationHelper.IsUpdating(weapon.VersatileDamage, updateModel.VersatileDamage))
                weapon.VersatileDamage = updateModel.VersatileDamage;
        }
        else if (entity is ArmorItemDescription armor)
        {
            if (ModelManipulationHelper.IsUpdating(armor.ArmorCategory, updateModel.ArmorCategory))
                armor.ArmorCategory = updateModel.ArmorCategory;
            
            if (ModelManipulationHelper.IsUpdating(armor.ArmorClass, updateModel.ArmorClass))
                armor.ArmorClass = updateModel.ArmorClass;
            
            if (ModelManipulationHelper.IsUpdating(armor.Requirement, updateModel.Requirement))
                armor.Requirement = updateModel.Requirement;
            
            if (ModelManipulationHelper.IsUpdating(armor.Detriments, updateModel.Detriments))
                armor.Detriments = updateModel.Detriments;
        }
        else if (entity is ContainerItemDescription container)
        {
            if (ModelManipulationHelper.IsUpdating(updateModel.WeightCapacity, out var weightCapacity))
                container.WeightCapacity = weightCapacity;

            if (ModelManipulationHelper.IsUpdating(updateModel.AreaCapacity, out var areaCapacity))
                container.AreaCapacity = areaCapacity;
            
            if (ModelManipulationHelper.IsUpdating(updateModel.QuantityCapacity, out var quantityCapacity))
                container.QuantityCapacity = quantityCapacity;

            if (container is FillableContainerItemDescription fillable)
            {
                if (updateModel.Fill is double fill)
                    fillable.Fill = fill;

                if (ModelManipulationHelper.IsUpdating(updateModel.WeightWhenFull, out var wwfull))
                    fillable.WeightWhenFull = wwfull;
            }
        }

        return (object)entity;
    }

    public override async ValueTask<SuccessResult<IBaseItemDescriptionModel>> CreateEntity(DnDToolsUser? requester, ItemDescriptionCreationModel creationModel)
    {
        ErrorList er = default;
        var characters = CharacterRepository.GetEditableEntities(requester);
        if (requester is null || characters is null) 
        {
            er.AddNoPermission();
            return er;
        }

        ItemDescription? item = null;

        if (string.IsNullOrWhiteSpace(creationModel.EntityType))
            er.AddEmptyProperty(nameof(creationModel.EntityType));
        else if (ThisAsRepo.TryGetItemSchemaInfo(creationModel.EntityType, out var schema, out var clrType, out var dataModelClrType) is false)
            er.AddEntityNotFound(nameof(ItemDescriptionSchema), $"entityType:{creationModel.EntityType}");
        else
            item = (ItemDescription)Activator.CreateInstance(dataModelClrType)!;

        Debug.Assert(item is IBaseItemDescriptionModel);
        InventoryModel? inv;
                
        if (creationModel.Inventory is Guid newinv)
        {
            inv = await characters.Where(x => x.Inventories != null)
                                  .SelectMany(x => x.Inventories!)
                                  .FirstOrDefaultAsync(x => x.Id == newinv);
            if (inv is null) 
                er.AddEntityNotFound("Inventory", $"id:{newinv}");
        }
        else
            er.AddEmptyProperty(nameof(creationModel.Inventory));

        if (er.Count > 0)
            return er;

        Debug.Assert(inv is not null);
        Debug.Assert(item is not null);

        if (creationModel.BasePrice is Money basePrice)
            item.BasePrice = basePrice;

        if (creationModel.Size is Area size)
            item.Size = size;

        if (creationModel.Weight is Mass weight)
            item.WeightPerItem = weight;

        if (creationModel.Amount is Quantity amount)
            item.Amount = amount;

        item.Tags = creationModel.Tags?.ToHashSet(CaseInsensitiveStringComparer.Instance);
        item.Notes = creationModel.Notes;
        item.Description = creationModel.Description;
        item.Name = creationModel.Name;

        if (item is WeaponItemDescription weapon)
        {
            weapon.WeaponCategory = creationModel.WeaponCategory;
            weapon.DamageType = creationModel.DamageType;
            weapon.Range = creationModel.Range;
            weapon.ThrownRange = creationModel.ThrownRange;
            weapon.DamageThrow = creationModel.DamageThrow;
            weapon.GraspType = creationModel.GraspType;
            weapon.VersatileDamage = creationModel.VersatileDamage;
        }
        else if (item is ArmorItemDescription armor)
        {
            armor.ArmorCategory = creationModel.ArmorCategory;
            armor.ArmorClass = creationModel.ArmorClass;
            armor.Requirement = creationModel.Requirement;
            armor.Detriments = creationModel.Detriments;
        }
        else if (item is ContainerItemDescription container)
        {
            container.WeightCapacity = creationModel.WeightCapacity;
            container.AreaCapacity = creationModel.AreaCapacity;
            container.QuantityCapacity = creationModel.QuantityCapacity;
            if (container is FillableContainerItemDescription fillable)
            {
                fillable.Fill = creationModel.Fill ?? 0;
                fillable.WeightWhenFull = creationModel.WeightWhenFull;
            }
        }

        var result = (IBaseItemDescriptionModel)item;
        inv.Items.Add(result);
        return new(result);
    }

    public override ValueTask<SuccessResult<object>> GetView(DnDToolsUser? requester, IBaseItemDescriptionModel entity)
    {
        ErrorList err = new();
        if (requester is null)
        {
            err.AddNoPermission();
            return new(err);
        }

        ArgumentNullException.ThrowIfNull(entity);

        var view = new ItemDescriptionView();

        var item = (ItemDescription)entity;

        view.Id = entity.Id;
        view.ContainerId = entity.ContainerInventoryId;
        view.Name = item.Name;
        view.EntityType = item.EntityType;
        view.BasePrice = item.BasePrice;
        view.Size = item.Size;
        view.WeightPerItem = item.WeightPerItem;
        view.Amount = item.Amount;
        view.Tags = item.Tags?.ToHashSet(CaseInsensitiveStringComparer.Instance);
        view.Notes = item.Notes;
        view.Description = item.Description;

        if (item is WeaponItemDescription weapon)
        {
            view.WeaponCategory = weapon.WeaponCategory;
            view.DamageType = weapon.DamageType;
            view.Range = weapon.Range;
            view.ThrownRange = weapon.ThrownRange;
            view.DamageThrow = weapon.DamageThrow;
            view.GraspType = weapon.GraspType;
            view.VersatileDamage = weapon.VersatileDamage;
        }
        else if (item is ArmorItemDescription armor)
        {
            view.ArmorCategory = armor.ArmorCategory;
            view.ArmorClass = armor.ArmorClass;
            view.Requirement = armor.Requirement;
            view.Detriments = armor.Detriments;
        }
        else if (item is ContainerItemDescription container)
        {
            view.WeightCapacity = container.WeightCapacity;
            view.AreaCapacity = container.AreaCapacity;
            view.QuantityCapacity = container.QuantityCapacity;

            if (container is FillableContainerItemDescription fillable)
            {
                view.Fill = fillable.Fill;
                view.WeightWhenFull = fillable.WeightWhenFull;
            }
        }

        return ValueTask.FromResult<SuccessResult<object>>(view);
    }

    public override ValueTask<SuccessResult?> DeleteEntity(DnDToolsUser? requester, Guid id)
    {
        return base.DeleteEntity(requester, id);
    }

    public override ValueTask<SuccessResult> DeleteEntity(DnDToolsUser? requester, IBaseItemDescriptionModel entity)
    {
        return base.DeleteEntity(requester, entity);
    }

    public override IQueryable<ItemDescriptionView>? GetViews(DnDToolsUser? requester, IQueryable<IBaseItemDescriptionModel> entities)
    {
        if (requester is null || entities is null) return null;

        // This time, we gotta trust entites is already filtered for user access

        return entities.Select(entity => new ItemDescriptionView()
        {
            Id = entity.Id,
            ContainerId = entity.ContainerInventoryId,
            Name = ((ItemDescription)entity).Name,
            EntityType = ((ItemDescription)entity).EntityType,
            BasePrice = ((ItemDescription)entity).BasePrice,
            Size = ((ItemDescription)entity).Size,
            WeightPerItem = ((ItemDescription)entity).WeightPerItem,
            Amount = ((ItemDescription)entity).Amount,
            Tags = ((ItemDescription)entity).Tags,
            Notes = ((ItemDescription)entity).Notes,
            Description = ((ItemDescription)entity).Description,

            WeaponCategory = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).WeaponCategory : null,
            DamageType = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).DamageType : null,
            Range = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).Range : null,
            ThrownRange = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).ThrownRange : null,
            DamageThrow = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).DamageThrow : null,
            GraspType = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).GraspType : null,
            VersatileDamage = (entity as WeaponItemDescription) != null ? ((WeaponItemDescription)entity).VersatileDamage : null,

            ArmorCategory = (entity as ArmorItemDescription) != null ? ((ArmorItemDescription)entity).ArmorCategory : null,
            ArmorClass = (entity as ArmorItemDescription) != null ? ((ArmorItemDescription)entity).ArmorClass : null,
            Requirement = (entity as ArmorItemDescription) != null ? ((ArmorItemDescription)entity).Requirement : null,
            Detriments = (entity as ArmorItemDescription) != null ? ((ArmorItemDescription)entity).Detriments : null,

            WeightCapacity = (entity as ContainerItemDescription) != null ? ((ContainerItemDescription)entity).WeightCapacity : null,
            AreaCapacity = (entity as ContainerItemDescription) != null ? ((ContainerItemDescription)entity).AreaCapacity : null,
            QuantityCapacity = (entity as ContainerItemDescription) != null ? ((ContainerItemDescription)entity).QuantityCapacity : null,

            Fill = (entity as FillableContainerItemDescription) != null ? ((FillableContainerItemDescription)entity).Fill : null,
            WeightWhenFull = (entity as FillableContainerItemDescription) != null ? ((FillableContainerItemDescription)entity).WeightWhenFull : null
        });
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntities(DnDToolsUser? requester)
    {
        if (requester is null)
            return null;

        return CharacterRepository
                      .GetEditableEntities(requester)
                     ?.Where(x => x.Inventories != null)
                      .SelectMany(x => x.Inventories!)
                      .SelectMany(x => x.Items);
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesInInventory(DnDToolsUser? requester, Guid inventoryId)
    {
        if (requester is null)
            return null;

        return CharacterRepository
                      .GetEditableEntities(requester)
                     ?.Where(x => x.Inventories != null)
                      .SelectMany(x => x.Inventories!)
                      .Where(x => x.Id == inventoryId)
                      .SelectMany(x => x.Items);
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesInInventory(DnDToolsUser? requester, InventoryModel inventory)
        => GetEditableEntitiesInInventory(requester, (inventory ?? throw new ArgumentNullException(nameof(inventory))).Id);

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesFromCharacter(DnDToolsUser? requester, Guid characterId)
    {
        if (requester is null)
            return null;

        return CharacterRepository
                      .GetEditableEntities(requester)
                     ?.Where(x => x.Id == characterId)
                      .Where(x => x.Inventories != null)
                      .SelectMany(x => x.Inventories!)
                      .SelectMany(x => x.Items);
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesFromCharacter(DnDToolsUser? requester, DnDToolsCharacter character)
        => GetEditableEntitiesFromCharacter(requester, character.Id);
}
