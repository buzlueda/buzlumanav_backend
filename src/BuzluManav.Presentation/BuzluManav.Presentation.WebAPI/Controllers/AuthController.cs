using BuzluManav.Core.Application.Features.Auth.Commands.Login;
using BuzluManav.Core.Application.Features.Auth.Commands.Register;
using BuzluManav.Core.Application.Features.Auth.Models;
using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using Microsoft.AspNetCore.Mvc;

namespace BuzluManav.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterModel registerModel)
    {
        registerModel.IpAddress = getIpAddress() ?? throw new BusinessException("IP address not found");
        RegisterCommand registerCommand = new() { RegisterModel = registerModel };
        var result = await Mediator.Send(registerCommand);
        return HandleErrors(() => result.ToHttpResponse());
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginModel loginModel)
    {
        loginModel.IpAddress = getIpAddress() ?? throw new BusinessException("IP address not found");
        LoginCommand loginCommand = new() { LoginModel = loginModel };
        var result = await Mediator.Send(loginCommand);
        return HandleErrors(() => result.ToHttpResponse());
    }
}