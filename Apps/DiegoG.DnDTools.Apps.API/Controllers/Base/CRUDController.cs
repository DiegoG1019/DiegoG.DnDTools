using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class CRUDController<TEntity, TCreationModel, TUpdateModel>(
    ICRUDRepository<TEntity, TCreationModel, TUpdateModel> entityRepository, 
    UserManager<DnDToolsUser> userManager,
    ILogger<CRUDController<TEntity, TCreationModel, TUpdateModel>> logger
) : CreateReadDeleteController<TEntity, TCreationModel>(entityRepository, userManager, logger)
{
    protected override ICRUDRepository<TEntity, TCreationModel, TUpdateModel> Repository 
        => (ICRUDRepository<TEntity, TCreationModel, TUpdateModel>)base.Repository;
    
    [HttpPut("{key}")]
    public virtual async Task<IActionResult> Update([FromBody] TUpdateModel update, Guid key)
    {
        var u = await GetDnDToolsUser();
        var r = await Repository.UpdateEntity(u, key, update);

        if (r is not SuccessResult<object> result)
            return NotFound();

        if (result.TryGetResult(out var view))
        {
            await Repository.SaveChanges();
            return Ok(view);
        }

        return FailureResult(result);
    }
}
