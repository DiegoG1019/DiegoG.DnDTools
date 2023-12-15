using System.Net;
using DiegoG.DnDTools.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace DiegoG.DnDTools.Apps.API.Controllers;

public abstract class AppController : Controller
{
    protected virtual IActionResult Forbidden(object? value) 
        => new ObjectResult(value) { StatusCode = (int)HttpStatusCode.Forbidden };

    protected virtual IActionResult FailureResult(SuccessResult result)
        => new ObjectResult(result.ErrorMessages.Errors) { StatusCode = (int?)result.ErrorMessages.RecommendedCode ?? 418 };

    protected virtual IActionResult FailureResult<T>(SuccessResult<T> result)
        => new ObjectResult(result.ErrorMessages.Errors) { StatusCode = (int?)result.ErrorMessages.RecommendedCode ?? 418 };
}
