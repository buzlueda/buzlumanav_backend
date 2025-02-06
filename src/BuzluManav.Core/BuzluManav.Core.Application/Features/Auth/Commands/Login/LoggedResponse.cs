using BuzluManav.Core.Domain.Entities;
using CorePackages.Core.Application.Responses;
using CorePackages.Infrastructure.Security.Helpers.JWTHelpers;

namespace BuzluManav.Core.Application.Features.Auth.Commands.Login;

public record LoggedResponse : IResponse
{
    public AccessToken AccessToken { get; set; } = new();
    public RefreshToken RefreshToken { get; set; } = new();
    public Guid UserId { get; set; } = Guid.Empty;
    public int OperationClaimId { get; set; }
    public string OperationClaimName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Fullname { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;

    public LoggedResponse()
    {

    }

    public LoggedHttpResponse ToHttpResponse() =>
        new LoggedHttpResponse { AccessToken = AccessToken, UserId = UserId, OperationClaimId = OperationClaimId, OperationClaimName = OperationClaimName, Email = Email, Username = Username, Fullname = Fullname, Avatar = Avatar };
}

public class LoggedHttpResponse
{
    public AccessToken? AccessToken { get; init; }
    public Guid UserId { get; init; }
    public int OperationClaimId { get; init; }
    public string OperationClaimName { get; init; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Fullname { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}