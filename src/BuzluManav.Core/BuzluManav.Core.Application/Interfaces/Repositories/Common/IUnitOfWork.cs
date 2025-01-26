namespace BuzluManav.Core.Application.Interfaces.Repositories.Common;

public interface IUnitOfWork
{
    IBasketItemRepository BasketItemRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICityRepository CityRepository { get; }
    IDistrictRepository DistrictRepository { get; }
    IOperationClaimRepository OperationClaimRepository { get; }
    IOrderItemRepository OrderItemRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderStatusRepository OrderStatusRepository { get; }
    IProductRepository ProductRepository { get; }
    IRefreshTokenRepository RefreshTokenRepository { get; }
    IUserAddressRepository UserAddressRepository { get; }
    IUserFavoriteItemRepository UserFavoriteItemRepository { get; }
    IUserRepository UserRepository { get; }
}