using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class City : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<District> Districts { get; set; } = new HashSet<District>();
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new HashSet<UserAddress>();
}