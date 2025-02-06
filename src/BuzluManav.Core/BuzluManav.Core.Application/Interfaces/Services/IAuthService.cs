using BuzluManav.Core.Application.Features.Auth.Commands.Login;
using BuzluManav.Core.Application.Features.Auth.Commands.Register;
using BuzluManav.Core.Application.Features.Auth.Models;

namespace BuzluManav.Core.Application.Interfaces.Services;

public interface IAuthService
{
    Task<LoggedResponse> LoginAsync(LoginModel loginModel);
    Task<RegisteredResponse> RegisterAsync(RegisterModel registerModel);
}