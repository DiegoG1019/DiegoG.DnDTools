using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.EntityFramework.Repositories.Base;

public abstract class EntityFrameworkReadRepository<TEntity>(DnDToolsContext context)
    : IReadRepository<TEntity>
    where TEntity : class, IKeyed<TEntity, Guid>
{
    protected readonly DnDToolsContext Context = context ?? throw new ArgumentNullException(nameof(context));

    public abstract IQueryable<TEntity>? GetEntities(DnDToolsUser? requester);

    public async ValueTask<SuccessResult<TEntity>> FindEntity(DnDToolsUser? requester, Guid id)
    {
        var t = GetEntities(requester);
        if (t is not null)
        {
            var ent = await t.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ent is not null)
                return new SuccessResult<TEntity>(ent);
        }

        ErrorList errors = new();
        errors.AddError(ErrorMessages.EntityNotFound(typeof(TEntity).Name, $"id: {id}"));
        return new SuccessResult<TEntity>(errors);
    }

    public abstract ValueTask<SuccessResult<object>> GetView(DnDToolsUser? requester, TEntity entity);

    public abstract IQueryable<object>? GetViews(DnDToolsUser? requester, IQueryable<TEntity> entities);
}
