using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.EntityFramework.Repositories.Base;

public abstract class EntityFrameworkCRUDRepository<TEntity, TCreateEntityModel, TUpdateEntityModel>(DnDToolsContext context)
    : EntityFrameworkCreateReadDeleteRepository<TEntity, TCreateEntityModel>(context), ICRUDRepository<TEntity, TCreateEntityModel, TUpdateEntityModel>
    where TEntity : class, IKeyed<TEntity, Guid>
{
    public abstract ValueTask<SuccessResult<object>?> UpdateEntity(DnDToolsUser? requester, Guid key, TUpdateEntityModel updateModel);
}
