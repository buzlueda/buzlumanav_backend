using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IBasketItemRepository : IAsyncRepository<BasketItem, int>, IRepository<BasketItem, int>
{}