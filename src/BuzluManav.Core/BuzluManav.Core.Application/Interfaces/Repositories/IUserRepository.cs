using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{
}