using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IOrderRepository : IAsyncRepository<Order, int>, IRepository<Order, int>
{
}