namespace BuzluManav.Core.Domain.Entities
{
    using CorePackages.Infrastructure.Persistence.Repositories.Common;

    public class BasketItem : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}