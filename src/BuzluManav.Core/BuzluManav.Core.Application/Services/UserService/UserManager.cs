using AutoMapper;
using BuzluManav.Core.Application.Interfaces.Repositories.Common;
using BuzluManav.Core.Application.Interfaces.Services;
using BuzluManav.Core.Application.Services.UserService.Constants;
using BuzluManav.Core.Application.Services.UserService.Rules;
using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using Microsoft.EntityFrameworkCore;

namespace BuzluManav.Core.Application.Services.UserService;

public class UserManager(UserBusinessRules userBusinessRules, IMapper mapper, IUnitOfWork unitOfWork) : IUserService
{
    public async Task CheckIfUserExists(string email)
    {
        var user = await unitOfWork.UserRepository.GetAsync(
            predicate: u => u.Email == email
        );
        if (user is not null) throw new BusinessException(UserConstants.UserAlreadyExists);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await CheckIfUserExists(user.Email);
        var createdUser = await unitOfWork.UserRepository.AddAsync(user);
        createdUser.GenerateFullName();
        var userWithClaims = await unitOfWork.UserRepository.GetAsync(
            predicate: u => u.Id == createdUser.Id,
            include: source => source
                .Include(u => u.OperationClaim)
        );
        return userWithClaims!;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await unitOfWork.UserRepository.GetAsync(
            predicate: u => u.Email == email,
            include: source => source
                .Include(u => u.OperationClaim)
        );
        if (user is null) throw new BusinessException(UserConstants.UserDoesNotExist);
        return user!;
    }
}
