using DiegoG.DnDTools.Services.Common;

namespace DiegoG.DnDTools.Services.Data.Internal;

public interface ICreateReadDeleteRepository<TEntity, TCreateEntityModel> 
    : IReadRepository<TEntity>
{
    public ValueTask<SuccessResult> DeleteEntity(DnDToolsUser? requester, TEntity entity);
    public ValueTask<SuccessResult?> DeleteEntity(DnDToolsUser? requester, Guid id);
    public ValueTask<SuccessResult<TEntity>> CreateEntity(DnDToolsUser? requester, TCreateEntityModel creationModel);

    public ValueTask<SuccessResult> SaveChanges();
}
