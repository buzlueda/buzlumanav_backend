using BuzluManav.Core.Domain.Entities;
using CorePackages.Core.Application.Responses;
using CorePackages.Infrastructure.Security.Helpers.JWTHelpers;

namespace BuzluManav.Core.Application.Features.Auth.Commands.Register;

public record RegisteredResponse : IResponse
{
    public AccessToken AccessToken { get; set; } = new();
    public RefreshToken RefreshToken { get; set; } = new();
    public Guid UserId { get; set; } = Guid.Empty;
    public int OperationClaimId { get; set; }
    public string OperationClaimName { get; set; } = string.Empty;
    public RegisteredResponse()
    {

    }
    public RegisteredHttpResponse ToHttpResponse() =>
        new RegisteredHttpResponse { AccessToken = AccessToken, UserId = UserId, OperationClaimId = OperationClaimId, OperationClaimName = OperationClaimName };
}

public class RegisteredHttpResponse{
    public AccessToken? AccessToken {get; init;}
    public Guid UserId {get; init;}
    public int OperationClaimId { get; init; }
    public string OperationClaimName { get; init; } = string.Empty;
}