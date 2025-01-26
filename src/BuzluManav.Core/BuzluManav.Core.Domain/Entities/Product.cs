using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class Product : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public virtual ICollection<BasketItem> BasketItems { get; set; } = new HashSet<BasketItem>();
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}