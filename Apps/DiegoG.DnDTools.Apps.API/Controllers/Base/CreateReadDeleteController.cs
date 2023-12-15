using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class CreateReadDeleteController<TEntity, TCreationModel>(
    ICreateReadDeleteRepository<TEntity, TCreationModel> entityRepository,
    UserManager<DnDToolsUser> userManager
) : ReadController<TEntity>(entityRepository, userManager)
{
    protected override ICreateReadDeleteRepository<TEntity, TCreationModel> Repository
        => (ICreateReadDeleteRepository<TEntity, TCreationModel>)base.Repository;

    [HttpPost]
    public virtual async Task<IActionResult> CreateEntity([FromBody] TCreationModel creationModel)
    {
        var u = await UserManager.GetUserAsync(User);
        var result = await Repository.CreateEntity(u, creationModel);

        if (result.TryGetResult(out var created))
        {
            await Repository.SaveChanges();
            var view = await Repository.GetView(u, created);
            return view is not null ? Ok(view) : NotFound();
        }

        return FailureResult(result);
    }

    [HttpDelete("{key}")]
    public virtual async Task<IActionResult> DeleteEntity(Guid key)
    {
        var u = await UserManager.GetUserAsync(User);

        var r = await Repository.DeleteEntity(u, key);
        if (r is not SuccessResult result)
            return NotFound();
        else if (result.IsSuccess)
        {
            await Repository.SaveChanges();
            return Ok();
        }
        else
            return FailureResult(result);
    }
}
