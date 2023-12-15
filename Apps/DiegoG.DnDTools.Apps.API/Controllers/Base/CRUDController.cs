using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class CRUDController<TEntity, TCreationModel, TUpdateModel>(
    ICRUDRepository<TEntity, TCreationModel, TUpdateModel> entityRepository, 
    UserManager<DnDToolsUser> userManager
) : CreateReadDeleteController<TEntity, TCreationModel>(entityRepository, userManager)
{
    protected override ICRUDRepository<TEntity, TCreationModel, TUpdateModel> Repository 
        => (ICRUDRepository<TEntity, TCreationModel, TUpdateModel>)base.Repository;
    
    [HttpPut("{key}")]
    public async Task<IActionResult> Update([FromBody] TUpdateModel update, Guid key)
    {
        var u = await UserManager.GetUserAsync(User);
        var r = await Repository.UpdateEntity(u, key, update);

        if (r is not SuccessResult result)
            return NotFound();

        if (result.IsSuccess)
        {
            await Repository.SaveChanges();
            return Ok();
        }

        return FailureResult(result);
    }
}
