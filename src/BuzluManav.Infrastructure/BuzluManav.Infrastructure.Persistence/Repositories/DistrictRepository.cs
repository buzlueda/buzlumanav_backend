using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class DistrictRepository : EfRepositoryBase<District, int, BuzluManavDbContext>, IDistrictRepository
{
    public DistrictRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}