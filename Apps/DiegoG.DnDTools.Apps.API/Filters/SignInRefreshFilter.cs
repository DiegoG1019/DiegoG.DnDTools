using DiegoG.DnDTools.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DiegoG.DnDTools.Apps.API.Filters;

public sealed class SignInRefreshFilter<TAppUser> : IAsyncActionFilter
    where TAppUser : DnDToolsUser
{
    private SignInManager<TAppUser> SignInManager { get; }
    private UserManager<TAppUser> UserManager { get; }
    public SignInRefreshFilter(SignInManager<TAppUser> signInManager, UserManager<TAppUser> userManager)
    {
        SignInManager = signInManager;
        UserManager = userManager;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var ctx = await next();

        var u = await UserManager.GetUserAsync(ctx.HttpContext.User);
        if (u is not null)
            await SignInManager.RefreshSignInAsync(u);
    }
}
