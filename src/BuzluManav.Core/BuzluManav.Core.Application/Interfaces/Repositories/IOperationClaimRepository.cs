using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int>
{
}