using BuzluManav.Core.Domain.Entities;

namespace BuzluManav.Core.Application.Interfaces.Services;

public interface IRefreshTokenService
{
    Task AddRefreshToken(RefreshToken refreshToken);
    Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    Task DeleteOldRefreshTokens(Guid userId, int refreshTokenTTL);
}