using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Infrastructure.Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, int, BuzluManavDbContext>, IProductRepository
{
    public ProductRepository(BuzluManavDbContext dbContext) : base(dbContext)
    {
    }
}