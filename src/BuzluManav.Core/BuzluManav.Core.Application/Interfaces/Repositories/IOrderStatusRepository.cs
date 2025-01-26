using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IOrderStatusRepository : IAsyncRepository<OrderStatus, int>, IRepository<OrderStatus, int>
{
}