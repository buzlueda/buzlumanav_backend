using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface ICityRepository : IAsyncRepository<City, int>, IRepository<City, int>
{
}