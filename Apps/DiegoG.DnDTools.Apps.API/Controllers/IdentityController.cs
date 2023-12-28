using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Apps.API.Controllers;

[ApiController]
[Route("/api/identity")]
public sealed class IdentityController
    (IDnDToolsUserRepository userRepository, UserManager<DnDToolsUser> userManager, ILogger<IdentityController> logger, SignInManager<DnDToolsUser> signInManager) : AppController(userManager, logger)
{
    private readonly SignInManager<DnDToolsUser> SignInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    private readonly IDnDToolsUserRepository UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    [HttpPost]
    public async Task<IActionResult> CreateEntity([FromBody] DnDToolsUserCreationModel creationModel)
    {
        var result = await UserRepository.CreateEntity(null, creationModel);

        if (result.TryGetResult(out var created))
        {
            await UserRepository.SaveChanges();
            var viewresult = await UserRepository.GetView(created, created);
            return viewresult.TryGetResult(out var view) ? Ok(view) : FailureResult(viewresult);
        }

        return FailureResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> Login([FromBody] DnDToolsUserLoginModel? userLogin)
    {
        ErrorList list = new();

        if (userLogin is null)
        {
            list.AddEmptyBody();
            return BadRequest(list.Errors);
        }

        if (string.IsNullOrWhiteSpace(userLogin.UsernameOrEmail))
            list.AddBadUsername(userLogin.UsernameOrEmail ?? "");

        if (string.IsNullOrWhiteSpace(userLogin.Password))
            list.AddBadPassword();

        if (list.Count > 0)
            return BadRequest(list.Errors);

        Debug.Assert(string.IsNullOrWhiteSpace(userLogin.UsernameOrEmail) is false);
        Debug.Assert(string.IsNullOrWhiteSpace(userLogin.Password) is false);
        var user = await UserManager.FindByEmailAsync(userLogin.UsernameOrEmail) ?? await UserManager.FindByNameAsync(userLogin.UsernameOrEmail);
        if (user is null)
        {
            list.AddUserNotFound(userLogin.UsernameOrEmail);
            return NotFound(list.Errors);
        }

        Logger.LogInformation("Attempting to log in as user {user} ({userid})", userLogin.UsernameOrEmail, user.Id);

        var result = await SignInManager.PasswordSignInAsync(user, userLogin.Password, true, false);
        if (result.Succeeded)
        {
            Logger.LogInformation("Succesfully logged in as user {user} ({userid})", userLogin.UsernameOrEmail, user.Id);
            var viewresult = await UserRepository.GetView(user, user);
            return viewresult.TryGetResult(out var view) ? Ok(view) : FailureResult(viewresult);
        }
        else if (result.IsLockedOut)
        {
            Logger.LogInformation("Could not log in as user {user} ({userid}), because they're locked out", user.UserName!, user.Id);
            list.AddLoginLockedOut(user.UserName!);
            return Forbidden(list.Errors);
        }
        else if (result.RequiresTwoFactor)
        {
            Logger.LogInformation("Could not log in as user {user} ({userid}), because they require 2FA", user.UserName!, user.Id);
            list.AddLoginRequires("2FA", user.UserName!);
            return Forbidden(list.Errors);
        }
        else if (result.IsNotAllowed)
        {
            Logger.LogInformation("Could not log in as user {user} ({userid}), because they're not allowed to", user.UserName!, user.Id);
            list.AddActionDisallowed("LogIn");
            return Forbidden(list.Errors);
        }
        else
        {
            Logger.LogInformation("Could not log in as user {user} ({userid})", user.UserName!, user.Id);
            list.AddBadLogin();
            return BadRequest(list.Errors);
        }
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Logout()
    {
        await SignInManager.SignOutAsync();
        return Ok();
    }

    [Authorize]
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        var u = await UserManager.GetUserAsync(User);
        if (u is null || string.Equals(u.Email, "admin@admin.com", StringComparison.OrdinalIgnoreCase) is false)
            return Unauthorized();

        var findResult = await UserRepository.FindEntity(u, userId);
        if (findResult.TryGetResult(out var entity) is false)
            return NotFound();

        var result = await UserRepository.DeleteEntity(u, entity);

        return result.IsSuccess ? Ok() : FailureResult(result);
    }
}
