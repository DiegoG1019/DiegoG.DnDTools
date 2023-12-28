using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.Data.Internal;

public interface ICRUDRepository<TEntity, TCreateEntityModel, TUpdateEntityModel> 
    : ICreateReadDeleteRepository<TEntity, TCreateEntityModel>
{
    public ValueTask<SuccessResult<object>?> UpdateEntity(DnDToolsUser? requester, Guid key, TUpdateEntityModel updateModel);
}
