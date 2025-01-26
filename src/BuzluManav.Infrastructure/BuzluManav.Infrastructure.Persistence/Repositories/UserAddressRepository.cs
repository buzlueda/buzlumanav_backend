using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class UserAddressRepository : EfRepositoryBase<UserAddress, int, BuzluManavDbContext>, IUserAddressRepository
{
    public UserAddressRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}