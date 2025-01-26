using BuzluManav.Core.Application.Interfaces.Repositories;
using BuzluManav.Core.Application.Interfaces.Repositories.Common;
using BuzluManav.Infrastructure.Persistence.Contexts;

namespace BuzluManav.Infrastructure.Persistence.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly BuzluManavDbContext _dbContext;
    public UnitOfWork(BuzluManavDbContext dbContext)
    {
        _dbContext = dbContext;
        BasketItemRepository = new BasketItemRepository(_dbContext);
        CategoryRepository = new CategoryRepository(_dbContext);
        CityRepository = new CityRepository(_dbContext);
        DistrictRepository = new DistrictRepository(_dbContext);
        OperationClaimRepository = new OperationClaimRepository(_dbContext);
        OrderItemRepository = new OrderItemRepository(_dbContext);
        OrderRepository = new OrderRepository(_dbContext);
        OrderStatusRepository = new OrderStatusRepository(_dbContext);
        ProductRepository = new ProductRepository(_dbContext);
        RefreshTokenRepository = new RefreshTokenRepository(_dbContext);
        UserAddressRepository = new UserAddressRepository(_dbContext);
        UserFavoriteItemRepository = new UserFavoriteItemRepository(_dbContext);
        UserRepository = new UserRepository(_dbContext);
    }

    public IBasketItemRepository BasketItemRepository { get; private set; }

    public ICategoryRepository CategoryRepository { get; private set; }

    public ICityRepository CityRepository { get; private set; }

    public IDistrictRepository DistrictRepository { get; private set; }

    public IOperationClaimRepository OperationClaimRepository { get; private set; }

    public IOrderItemRepository OrderItemRepository { get; private set; }

    public IOrderRepository OrderRepository { get; private set; }

    public IOrderStatusRepository OrderStatusRepository { get; private set; }

    public IProductRepository ProductRepository { get; private set; }

    public IRefreshTokenRepository RefreshTokenRepository { get; private set; }

    public IUserAddressRepository UserAddressRepository { get; private set; }

    public IUserFavoriteItemRepository UserFavoriteItemRepository { get; private set; }

    public IUserRepository UserRepository { get; private set; }
}