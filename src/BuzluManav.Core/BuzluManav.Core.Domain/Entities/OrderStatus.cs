using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class OrderStatus : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}