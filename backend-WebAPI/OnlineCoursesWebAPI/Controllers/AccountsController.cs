using System.Net;
using Core.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCoursesWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController(IAccountsService accountsService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        await accountsService.Register(model);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var loginResponse = await accountsService.Login(model);
        return Ok(loginResponse);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await accountsService.Logout();
        return Ok();
    }

    [HttpPost("send-reset-password-token")]
    public async Task<IActionResult> SendPasswordResetToken(PasswordResetTokenRequest req)
    {
        await accountsService.SendPasswordResetToken(req);
        return Ok(new
        {
            Message = "Mail sent if account exists",
            Status = HttpStatusCode.OK
        });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
    {
        await accountsService.ResetPassword(model);
        return Ok();
    }
}
