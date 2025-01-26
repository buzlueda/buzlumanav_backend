using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IUserAddressRepository : IAsyncRepository<UserAddress, int>, IRepository<UserAddress, int>
{
}