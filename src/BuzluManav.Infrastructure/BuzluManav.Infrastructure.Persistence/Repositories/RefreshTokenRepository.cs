using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, BuzluManavDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}