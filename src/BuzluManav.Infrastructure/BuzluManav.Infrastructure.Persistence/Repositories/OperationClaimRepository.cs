using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BuzluManavDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}