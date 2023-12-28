using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class ReadController<TEntity>(
    IReadRepository<TEntity> entityRepository, 
    UserManager<DnDToolsUser> userManager,
    ILogger<ReadController<TEntity>> logger
) : AppController(userManager, logger)
{
    protected virtual IReadRepository<TEntity> Repository { get; }
        = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));

    [HttpGet("query")]
    public virtual async Task<ActionResult<IQueryable<object>>> QueryEntities()
    {
        var u = await GetDnDToolsUser();
        var ents = Repository.GetEntities(u);
        return ents is null ? NotFound() : Ok(Repository.GetViews(u, ents));
    }

    [HttpGet("{key}")]
    public virtual async Task<IActionResult> ViewEntity(Guid key)
    {
        var u = await GetDnDToolsUser();
        var findResult = await Repository.FindEntity(u, key);

        if (findResult.TryGetResult(out var foundEntity) is false)
            return FailureResult(findResult);

        var viewResult = await Repository.GetView(u, foundEntity);
        return viewResult.TryGetResult(out var view) ? Ok(view) : FailureResult(viewResult);
    }
}
