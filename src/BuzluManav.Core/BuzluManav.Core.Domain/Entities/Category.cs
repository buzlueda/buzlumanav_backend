using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class Category : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}