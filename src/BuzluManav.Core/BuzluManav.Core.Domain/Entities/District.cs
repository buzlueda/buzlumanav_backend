using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class District : BaseEntity<int>
{
    public int CityId { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual City City { get; set; } = null!;
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new HashSet<UserAddress>();
}