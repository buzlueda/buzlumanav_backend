using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class OrderStatusRepository : EfRepositoryBase<OrderStatus, int, BuzluManavDbContext>, IOrderStatusRepository
{
    public OrderStatusRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}