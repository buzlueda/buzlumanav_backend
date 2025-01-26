using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IUserFavoriteItemRepository : IAsyncRepository<UserFavoriteItem, int>, IRepository<UserFavoriteItem, int>
{
}