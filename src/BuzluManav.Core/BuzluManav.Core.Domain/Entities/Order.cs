using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class Order : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int AddressId { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public int OrderStatusId { get; set; }
    public decimal TotalPrice { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual UserAddress Address { get; set; } = null!;
    public virtual OrderStatus OrderStatus { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}