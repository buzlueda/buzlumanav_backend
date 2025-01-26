using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class UserFavoriteItem : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}