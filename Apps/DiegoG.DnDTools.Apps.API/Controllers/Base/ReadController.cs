using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class ReadController<TEntity>(
    IReadRepository<TEntity> entityRepository, 
    UserManager<DnDToolsUser> userManager
) : AppController
{
    protected virtual IReadRepository<TEntity> Repository { get; }
        = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));

    protected UserManager<DnDToolsUser> UserManager { get; } = userManager ?? throw new ArgumentNullException(nameof(userManager));

    [HttpGet("query")]
    public async Task<ActionResult<IQueryable<object>>> QueryEntities()
    {
        var u = await UserManager.GetUserAsync(User);
        return Ok(Repository.GetViews(u, Repository.GetEntities(u)));
    }

    [HttpGet("{key}")]
    public virtual async Task<IActionResult> ViewEntity(Guid key)
    {
        var u = await UserManager.GetUserAsync(User);
        var foundEntity = await Repository.FindEntity(u, key);
        if (foundEntity is null)
            return NotFound();

        var view = await Repository.GetView(u, foundEntity);
        return view is not null ? Ok(view) : NotFound(null);
    }
}
