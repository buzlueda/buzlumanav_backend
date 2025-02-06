using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Security.Helpers.JWTHelpers;

namespace BuzluManav.Core.Application.Interfaces.Helpers;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, OperationClaim operationClaim);
    RefreshToken CreateRefreshToken(User user, string ipAddress);
}