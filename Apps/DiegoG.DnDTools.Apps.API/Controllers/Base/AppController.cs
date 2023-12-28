using System.Net;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class AppController(UserManager<DnDToolsUser> userManager, ILogger logger)
    : Controller
{
    protected readonly UserManager<DnDToolsUser> UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    protected readonly ILogger Logger = logger ?? throw new ArgumentNullException(nameof(logger));

    protected virtual IActionResult Forbidden(object? value) 
        => new ObjectResult(value) { StatusCode = (int)HttpStatusCode.Forbidden };

    protected virtual IActionResult FailureResult(SuccessResult result)
        => new ObjectResult(result.ErrorMessages.Errors) { StatusCode = (int?)result.ErrorMessages.RecommendedCode ?? 418 };

    protected virtual IActionResult FailureResult<T>(SuccessResult<T> result)
        => new ObjectResult(result.ErrorMessages.Errors) { StatusCode = (int?)result.ErrorMessages.RecommendedCode ?? 418 };

    private bool gotUser;
    private DnDToolsUser? user;
    protected async ValueTask<DnDToolsUser?> GetDnDToolsUser()
    {
        if (gotUser)
            return user;

        user = await UserManager.GetUserAsync(User);
        gotUser = true;
        return user;
    }
}
