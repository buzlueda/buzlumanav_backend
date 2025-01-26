using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IProductRepository : IAsyncRepository<Product, int>, IRepository<Product, int>
{
}