using System.Net;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Utilities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class CreateReadDeleteController<TEntity, TCreationModel>(
    ICreateReadDeleteRepository<TEntity, TCreationModel> entityRepository,
    UserManager<DnDToolsUser> userManager,
    ILogger<CreateReadDeleteController<TEntity, TCreationModel>> logger
) : ReadController<TEntity>(entityRepository, userManager, logger)
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
            var success = await Repository.GetView(u, created);
            return success.TryGetResult(out var view) ? StatusCode((int)HttpStatusCode.Created, view) : FailureResult(success);
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
