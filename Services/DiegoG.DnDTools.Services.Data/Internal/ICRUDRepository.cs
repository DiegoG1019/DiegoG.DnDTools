using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Common;

namespace DiegoG.DnDTools.Services.Data.Internal;

public interface ICRUDRepository<TEntity, TCreateEntityModel, TUpdateEntityModel> 
    : ICreateReadDeleteRepository<TEntity, TCreateEntityModel>
{
    public ValueTask<SuccessResult?> UpdateEntity(DnDToolsUser? requester, Guid key, TUpdateEntityModel updateModel);
}
