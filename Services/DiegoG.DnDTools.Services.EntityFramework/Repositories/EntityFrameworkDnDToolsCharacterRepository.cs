using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

public class EntityFrameworkDnDToolsCharacterRepository(DnDToolsContext context, IServiceProvider services)
    : EntityFrameworkCRUDRepository<DnDToolsCharacter, DnDToolsCharacterCreationModel, DnDToolsCharacterUpdateModel>(context),
    IDnDToolsCharacterRepository
{
    protected readonly IServiceProvider Services = services;

    public override IQueryable<DnDToolsCharacter>? GetEntities(DnDToolsUser? requester)
    {
        if (requester is null)
            return null;

        return Context.Users
                      .Where(x => x.Id == requester.Id && requester.AccesibleCharacters != null)
                      .SelectMany(x => x.AccesibleCharacters!)
                      .Union(Context.Users
                                    .Where(x => x.Id == requester.Id && requester.OwnedCharacters != null)
                                    .SelectMany(x => x.OwnedCharacters!)
                      ); 
    }

    public override async ValueTask<SuccessResult<object>?> UpdateEntity(DnDToolsUser? requester, Guid key, DnDToolsCharacterUpdateModel updateModel)
    {
        var characters = GetEditableEntities(requester);
        if (requester is null || characters is null) return null;
        var character = await characters.FirstOrDefaultAsync();

        ErrorList err = new();

        if (character is null)
        {
            err.AddEntityNotFound(nameof(DnDToolsCharacter), $"id: {key}");
            return new(err);
        }

        if (ModelManipulationHelper.IsUpdatingString(character.ReferenceImageUrl, updateModel.ReferenceImageUrl))
            character.ReferenceImageUrl = updateModel.ReferenceImageUrl;

        if (ModelManipulationHelper.IsUpdatingString(character.Name, updateModel.Name))
            character.Name = updateModel.Name;

        if (ModelManipulationHelper.IsUpdatingString(character.Description, updateModel.Description))
            character.Description = updateModel.Description;

        if (ModelManipulationHelper.IsUpdatingString(character.Notes, updateModel.Notes))
            character.Notes = updateModel.Notes;
        
        if (updateModel.Tags is not null)
        {
            var tagset = character.Tags?.ToHashSet(CaseInsensitiveStringComparer.Instance) ?? [];
            updateModel.Tags.PerformActionsString(tagset, ref err);

            if (err.Count > 0)
                return new(err);

            character.Tags = tagset;
        }

        if (updateModel.CharacterAccesses is not null)
        {
            var accessSet = await Context.CharacterAccesses.Where(x => x.CharacterId == key).Select(x => x.CharacterId).ToHashSetAsync();
            updateModel.CharacterAccesses.PerformActions(
                accessSet, 
                ref err, 
                (ea, i) => ea.ActionKind != EditActionKind.Clear && ea.Value == default 
                            ? ErrorMessages.InvalidProperty($"updateModel.CharacterAccesses:{i}")
                            : null
            );

            if (err.Count > 0)
                return new(err);

            var enumerable = Context
                .FromExpression(() => accessSet.AsQueryable())
                .Where(x => Context.Characters.Select(x => x.Id).Contains(x) == false)
                .AsAsyncEnumerable();

            await foreach (var id in enumerable)
                err.AddEntityNotFound(nameof(DnDToolsCharacter), $"id:{id}");

            return err.Count > 0 ? new(err) : SuccessResult.Success;
        }

        return SuccessResult.Success;
    }

    public override ValueTask<SuccessResult<DnDToolsCharacter>> CreateEntity(DnDToolsUser? requester, DnDToolsCharacterCreationModel creationModel)
    {
        ErrorList err = new();

        if (requester is null)
            return ValueTask.FromResult(new SuccessResult<DnDToolsCharacter>(err.AddNoPermission()));

        if (ModelManipulationHelper.IsEmptyString(ref err, creationModel.Name))
            return ValueTask.FromResult(new SuccessResult<DnDToolsCharacter>(err));

        var ent = new DnDToolsCharacter()
        {
            Id = Guid.NewGuid(),
            Name = creationModel.Name,
            Notes = creationModel.Notes,
            Owner = requester,
            OwnerId = requester.Id,
            ReferenceImageUrl = creationModel.ReferenceImageUrl,
            Tags = creationModel.Tags?.ToList(),
            Description = creationModel.Description,
        };

        Context.Characters.Add(ent);

        return ValueTask.FromResult(new SuccessResult<DnDToolsCharacter>(ent));
    }

    public override async ValueTask<SuccessResult<object>> GetView(DnDToolsUser? requester, DnDToolsCharacter entity)
    {
        if (requester is null) return SuccessResult<object>.Failure;

        var owner = await GetCharacterOwner(entity);
        return new SuccessResult<object>(new DnDToolsCharacterView()
        {
            Id = entity.Id,
            Inventories = entity.Inventories?.Select(x => new DnDToolsEmbeddedInventoryView()
            {
                Id = x.Id,
                Description = x.Description,
                ItemCount = x.Items?.Count ?? 0,
                Name = x.Name,
                OwnerId = x.CharacterId
            }),
            Name = entity.Name,
            Owner = owner is not null ? new()
            {
                Name = owner.UserName,
                EmailHashMD5 = owner.EmailMD5Hash,
                Id = owner.Id,
            } : null,
            OwnerId = owner?.Id ?? default,
            ReferenceImageUrl = entity.ReferenceImageUrl
        });
    }

    public override IQueryable<object>? GetViews(DnDToolsUser? requester, IQueryable<DnDToolsCharacter> entities)
    {
        if (requester is null) return null;

        return entities.Select(x => new DnDToolsCharacterView()
        {
            Id = x.Id,
            Inventories = x.Inventories == null ? null : x.Inventories.Select(x => new DnDToolsEmbeddedInventoryView()
            {
                Id = x.Id,
                Description = x.Description,
                ItemCount = x.Items != null ? x.Items.Count : 0,
                Name = x.Name,
                OwnerId = x.CharacterId
            }),
            Name = x.Name,
            Owner = x.Owner == null ? null : new DnDToolsEmbeddedUserView()
            {
                Id = x.Owner.Id,
                EmailHashMD5 = x.Owner.EmailMD5Hash,
                Name = x.Owner.UserName
            },
            OwnerId = x.OwnerId,
            ReferenceImageUrl = x.ReferenceImageUrl
        });
    }

    public async ValueTask<DnDToolsUser?> GetCharacterOwner(DnDToolsCharacter entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return entity.Owner is not null ? entity.Owner : await Context.Users.Where(x => x.Id == entity.OwnerId).FirstOrDefaultAsync();
    }

    private async Task<int> DeleteRelations(DnDToolsUser requester, Guid id)
    {
        var invrepo = Services.GetRequiredService<IInventoryRepository>();
        await invrepo.DeleteEntities(requester, Context.Inventories.Where(x => x.CharacterId == id));
        return await Context.CharacterAccesses.Where(x => x.CharacterId == id).ExecuteDeleteAsync();
    }

    private async Task<int> DeleteRelations(DnDToolsUser requester, IEnumerable<Guid> ids)
    {
        var invrepo = Services.GetRequiredService<IInventoryRepository>();
        await invrepo.DeleteEntities(requester, Context.Inventories.Where(x => ids.Contains(x.CharacterId)));
        return await Context.CharacterAccesses.Where(x => ids.Contains(x.CharacterId)).ExecuteDeleteAsync();
    }

    public override async ValueTask<SuccessResult> DeleteEntity(DnDToolsUser? requester, DnDToolsCharacter entity)
    {
        if (requester is null)
        {
            ErrorList err = new();
            err.AddNoPermission();
            return err;
        }

        await DeleteRelations(requester, entity.Id);
        return await base.DeleteEntity(requester, entity);
    }

    public override async ValueTask<SuccessResult?> DeleteEntity(DnDToolsUser? requester, Guid id)
    {
        if (requester is null)
        {
            ErrorList err = new();
            err.AddNoPermission();
            return err;
        }

        await DeleteRelations(requester, id);
        return await base.DeleteEntity(requester, id);
    }

    public override async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<DnDToolsCharacter> entities)
    {
        if (requester is null)
            return -1;

        await DeleteRelations(requester, entities.Select(x => x.Id));
        return await base.DeleteEntities(requester, entities);
    }

    public override async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<Guid> ids)
    {
        if (requester is null)
            return -1;

        await DeleteRelations(requester, ids);
        return await base.DeleteEntities(requester, ids);
    }

    public IQueryable<DnDToolsCharacter>? GetEditableEntities(DnDToolsUser? requester)
    {
        if (requester is null)
            return null;

        return Context.CharacterAccesses
                      .Where(x => x.UserId == requester.Id && x.CanEdit)
                      .Select(x => x.Character!)
                      .Union(Context.Users
                                    .Where(x => x.Id == requester.Id && requester.OwnedCharacters != null)
                                    .SelectMany(x => x.OwnedCharacters!)
                      );
    }
}
