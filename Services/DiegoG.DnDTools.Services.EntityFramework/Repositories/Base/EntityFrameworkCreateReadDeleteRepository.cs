using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using DiegoG.DnDTools.Services.Utilities;
using System.Diagnostics;

namespace DiegoG.DnDTools.Services.EntityFramework.Repositories.Base;

public abstract class EntityFrameworkCreateReadDeleteRepository<TEntity, TCreateEntityModel>(DnDToolsContext context)
    : EntityFrameworkReadRepository<TEntity>(context), ICreateReadDeleteRepository<TEntity, TCreateEntityModel>
    where TEntity : class, IKeyed<TEntity, Guid>
{
    public virtual async ValueTask<SuccessResult> DeleteEntity(DnDToolsUser? requester, TEntity entity)
    {
        var entities = GetEntities(requester);
        var check = entities?.ContainsAsync(entity);
        if (check is null || await check is not true)
        {
            ErrorList err = new(HttpStatusCode.Forbidden);
            return new(err.AddEntityNotFound(typeof(TEntity).Name, $"id: {entity.Id}"));
        }

        Debug.Assert(entities is not null);
        await entities
            .Where(x => x.Id == entity.Id)
            .ExecuteDeleteAsync();

        return SuccessResult.Success;
    }

    public virtual async ValueTask<SuccessResult?> DeleteEntity(DnDToolsUser? requester, Guid id)
    {
        var entities = GetEntities(requester);
        var check = entities?.AnyAsync(x => x.Id == id);
        if (check is null || await check is not true)
        {
            ErrorList err = new(HttpStatusCode.Forbidden);
            return new(err.AddEntityNotFound(typeof(TEntity).Name, $"id: {id}"));
        }

        Debug.Assert(entities is not null);
        await entities
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        return SuccessResult.Success;
    }

    // requester is null ? 0 : await base.DeleteEntities(requester, GetEntities(requester)!.Where(x => ids.Contains(x.Id)));
    public virtual async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<Guid> ids)
    {
        var q = GetEntities(requester);
        return requester is null || q is null ? 0 : requester is null ? 0 : await q.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();
    }

    public virtual async ValueTask<int> DeleteEntities(DnDToolsUser? requester, IEnumerable<TEntity> entities)
    {
        var q = GetEntities(requester);
        return requester is null || q is null ? 0 : requester is null ? 0 : await q.Where(x => entities.Contains(x)).ExecuteDeleteAsync();
    }

    public abstract ValueTask<SuccessResult<TEntity>> CreateEntity(DnDToolsUser? requester, TCreateEntityModel creationModel);

    public virtual async ValueTask<SuccessResult> SaveChanges()
    {
        await Context.SaveChangesAsync();
        return SuccessResult.Success;
    }
}
