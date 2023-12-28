using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.Data.Internal;

public interface IReadRepository<TEntity>
{
    public IQueryable<TEntity>? GetEntities(DnDToolsUser? requester);
    public ValueTask<SuccessResult<TEntity>> FindEntity(DnDToolsUser? requester, Guid id);
    public ValueTask<SuccessResult<object>> GetView(DnDToolsUser? requester, TEntity entity);
    public IQueryable<object>? GetViews(DnDToolsUser? requester, IQueryable<TEntity> entities);
}
