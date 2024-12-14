using System.Net;
using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Core.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

public class AccountsService(
    IMapper mapper,
    IJwtService jwtService,
    ISendMailService mailService,
    UserManager<User> userManager,
    SignInManager<User> signInManager
    ) : IAccountsService
{
    public async Task<LoginResponse> Login(LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);

        if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
        {
            throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);
        }

        //await signInManager.SignInAsync(user, true);
        var claims = jwtService.GetClaims(user);
        var accessToken = jwtService.CreateToken(claims);
        return new LoginResponse { AccessToken = accessToken };
    }

    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }

    public async Task Register(RegisterModel model)
    {
        var user = mapper.Map<User>(model);
        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            throw new HttpException(string.Join("; ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
    }

    public async Task SendPasswordResetToken(PasswordResetTokenRequest req)
    {
        var user = await userManager.FindByEmailAsync(req.Email);

        if (user is null) return;

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        await mailService.SendEmailAsync(req.Email, user.FirstName ?? "", "Change password request", token);
    }

    public async Task ResetPassword(ResetPasswordModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email)
            ?? throw new HttpException("Invalid email!", HttpStatusCode.BadRequest);

       var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

        if (!result.Succeeded)
            throw new HttpException(string.Join("; ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
    }
}
