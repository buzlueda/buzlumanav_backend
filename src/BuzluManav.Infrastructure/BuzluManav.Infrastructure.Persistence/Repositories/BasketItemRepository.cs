using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class BasketItemRepository : EfRepositoryBase<BasketItem, int, BuzluManavDbContext>, IBasketItemRepository
{
    public BasketItemRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}