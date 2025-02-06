using AutoMapper;
using BuzluManav.Core.Application.Features.Auth.Commands.Login;
using BuzluManav.Core.Application.Features.Auth.Commands.Register;
using BuzluManav.Core.Application.Features.Auth.Models;
using BuzluManav.Core.Application.Interfaces.Helpers;
using BuzluManav.Core.Application.Interfaces.Services;
using BuzluManav.Core.Application.Services.AuthService.Constants;
using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using CorePackages.Infrastructure.Security.Helpers.HashingHelpers;
using CorePackages.Infrastructure.Security.Helpers.JWTHelpers;
using Microsoft.Extensions.Configuration;

namespace BuzluManav.Core.Application.Services.AuthService;

public class AuthManager(IConfiguration configuration, IMapper mapper, ITokenHelper tokenHelper, IUserService userService, IRefreshTokenService refreshTokenService) : IAuthService
{
    private TokenOptions TokenOptions { get; set; } = configuration.GetSection(AuthConstants.OptionsSection).Get<TokenOptions>() ?? throw new BusinessException(AuthConstants.TokenOptionsNotFound);
    public async Task<RegisteredResponse> RegisterAsync(RegisterModel registerModel)
    {
        var user = await CreateUserWithPassword(registerModel);
        var createdUser = await userService.CreateUserAsync(user);
        return await GenerateRegistrationResponse(createdUser, registerModel.IpAddress!);

    }

    private async Task<RegisteredResponse> GenerateRegistrationResponse(User registeredUser, string ipAddress)
    {
        var tokens = await GenerateTokenAsync(registeredUser, ipAddress);
        return MapToRegisteredResponse(registeredUser, tokens);
    }

    private RegisteredResponse MapToRegisteredResponse(User user, (AccessToken accessToken, RefreshToken refreshToken) tokens) =>
        new()
        {
            AccessToken = tokens.accessToken,
            RefreshToken = tokens.refreshToken,
            UserId = user.Id,
            OperationClaimId = user.OperationClaimId,
            OperationClaimName = user.OperationClaim.Name
        };

    private async Task<(AccessToken accessToken, RefreshToken refreshToken)> GenerateTokenAsync(User user, string ipAddress)
    {
        var accessToken = tokenHelper.CreateToken(user, user.OperationClaim);
        var refreshToken = await refreshTokenService.CreateRefreshToken(user, ipAddress);
        await refreshTokenService.AddRefreshToken(refreshToken);
        await refreshTokenService.DeleteOldRefreshTokens(user.Id, TokenOptions.RefreshTokenTTL);
        return (accessToken, refreshToken);
    }

    private async Task<User> CreateUserWithPassword(RegisterModel registerModel)
    {
        await userService.CheckIfUserExists(registerModel.Email);
        HashingHelper.CreatePasswordHash(registerModel.Password, out var passwordHash, out var passwordSalt);

        var user = mapper.Map<User>(registerModel);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.OperationClaimId = AuthConstants.Customer;

        return user;
    }

    public async Task<LoggedResponse> LoginAsync(LoginModel loginModel)
    {
        var user = await userService.GetUserByEmail(loginModel.Email);
        VerifyPassword(loginModel.Password, user.PasswordHash, user.PasswordSalt);
        var tokens = await GenerateTokenAsync(user, loginModel.IpAddress);
        return MapToLoggedResponse(user, tokens);
    }

    private LoggedResponse MapToLoggedResponse(User user, (AccessToken accessToken, RefreshToken refreshToken) tokens)
    {
        return new()
        {
            AccessToken = tokens.accessToken,
            RefreshToken = tokens.refreshToken,
            UserId = user.Id,
            OperationClaimId = user.OperationClaimId,
            OperationClaimName = user.OperationClaim.Name,
            Email = user.Email,
            Username = user.Username,
            Fullname = user.FullName,
            Avatar = user.ProfilePhotoUrl
        };
    }

    private void VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
            throw new BusinessException(AuthConstants.InvalidPassword);
    }

}