using BuzluManav.Core.Application.Features.Auth.Models;
using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Pipelines.Transaction;
using MediatR;

namespace BuzluManav.Core.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>, ITransactionalRequest
{
    public RegisterModel RegisterModel { get; set; } = new();

    public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await authService.RegisterAsync(request.RegisterModel);
            return result;

        }
    }
}