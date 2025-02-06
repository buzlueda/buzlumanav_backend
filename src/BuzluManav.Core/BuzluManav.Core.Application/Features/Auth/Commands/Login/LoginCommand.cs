using BuzluManav.Core.Application.Features.Auth.Models;
using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Pipelines.Transaction;
using MediatR;

namespace BuzluManav.Core.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>, ITransactionalRequest
{
    public LoginModel LoginModel { get; set; } = new();

    public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, LoggedResponse>
    {
        public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await authService.LoginAsync(request.LoginModel);
            return result;
        }
    }
}