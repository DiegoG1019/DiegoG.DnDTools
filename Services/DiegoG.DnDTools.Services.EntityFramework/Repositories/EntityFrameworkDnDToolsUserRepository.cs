using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Common.Responses.Views;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.EntityFramework.Repositories.Base;
using DiegoG.DnDTools.Services.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiegoG.DnDTools.Services.EntityFramework.Repositories;

public class EntityFrameworkDnDToolsUserRepository(DnDToolsContext context, UserManager<DnDToolsUser> userManager, IServiceProvider services) :
    EntityFrameworkCreateReadDeleteRepository<DnDToolsUser, DnDToolsUserCreationModel>(context),
    IDnDToolsUserRepository
{
    protected readonly UserManager<DnDToolsUser> UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    protected readonly IServiceProvider Services = services;

    public override IQueryable<DnDToolsUser>? GetEntities(DnDToolsUser? requester) 
        => requester is null ? (IQueryable<DnDToolsUser>?)null : Context.Users.Where(x => x.Id == requester.Id);

    public override async ValueTask<SuccessResult<DnDToolsUser>> CreateEntity(DnDToolsUser? requester, DnDToolsUserCreationModel creationModel)
    {
        ErrorList err = new();

        if (err.CheckIfEmail(creationModel.Email) is false
            | err.IsEmptyString(creationModel.Username)
            | err.IsEmptyString(creationModel.Password))  
            return err;
        // By using bitwise operators instead of comparison operators (| instead of ||) we forfeit the short circuit functionality, which means all the statements are ALWAYS checked, even if the solution is already known (i.e. one of the values is false). In this scenario, this is beneficial, since we want to check all properties for error reporting purposes

        Debug.Assert(creationModel.Email is not null);
        Debug.Assert(creationModel.Username is not null); 
        Debug.Assert(creationModel.Password is not null);

        var ent = new DnDToolsUser()
        {
            Id = Guid.NewGuid(),
            Email = creationModel.Email,
            UserName = creationModel.Username
        };

        var result = await UserManager.CreateAsync(ent, creationModel.Password);
        if (result.Succeeded is false)
        {
            err.AddIdentityErrors(result);
            return err;
        }

        return ent;
    }

    public override async ValueTask<SuccessResult<object>> GetView(DnDToolsUser? requester, DnDToolsUser entity)
    {
        ErrorList err = new();
        if (requester is null)
            return err.AddNoPermission();

        return new DnDToolsUserView()
        {
            EmailHashMD5 = entity.EmailMD5Hash,
            Id = entity.Id,
            Name = entity.UserName,
            Characters = await Context.Characters.Where(c => c.OwnerId == entity.Id).Select(c => new DnDToolsEmbeddedCharacterView()
            {
                Id = c.Id,
                Name = c.Name,
                OwnerId = entity.Id,
                ReferenceImageUrl = c.ReferenceImageUrl
            }).ToListAsync()
        };
    }

    public override IQueryable<object>? GetViews(DnDToolsUser? requester, IQueryable<DnDToolsUser> entities) 
        => requester is null
            ? null
            : entities.Select(x => new DnDToolsUserView()
            {
                EmailHashMD5 = x.EmailMD5Hash,
                Id = x.Id,
                Name = x.UserName,
                Characters = Context.Characters.Where(c => c.OwnerId == x.Id).Select(c => new DnDToolsEmbeddedCharacterView()
                {
                    Id = c.Id,
                    Name = c.Name,
                    OwnerId = x.Id,
                    ReferenceImageUrl = c.ReferenceImageUrl
                })
            });

    private ValueTask<int> DeleteOwnedCharacters(DnDToolsUser user)
    {
        var charrepo = Services.GetRequiredService<IDnDToolsCharacterRepository>();
        return charrepo.DeleteEntities(user, Context.Characters.Where(x => x.OwnerId == user.Id));
    }

    private ValueTask<int> DeleteOwnedCharacters(DnDToolsUser requester, IEnumerable<Guid> users)
    {
        var charrepo = Services.GetRequiredService<IDnDToolsCharacterRepository>();
        return charrepo.DeleteEntities(requester, Context.Characters.Where(x => users.Contains(x.OwnerId)));
    }

    public override async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<DnDToolsUser> entities)
    {
        if (requester is null) return -1;
        await DeleteOwnedCharacters(requester, entities.Select(x => x.Id));
        return await base.DeleteEntities(requester, entities);
    }

    public override async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<Guid> ids)
    {
        if (requester is null) return -1;
        await DeleteOwnedCharacters(requester, ids);
        return await base.DeleteEntities(requester, ids);
    }

    public override async ValueTask<SuccessResult> DeleteEntity(DnDToolsUser? requester, DnDToolsUser entity)
    {
        if (requester is null)
        {
            ErrorList errors = new();
            errors.AddNoPermission();
            return errors;
        }

        await DeleteOwnedCharacters(requester);
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

        await DeleteOwnedCharacters(requester);
        return await base.DeleteEntity(requester, id);
    }
}