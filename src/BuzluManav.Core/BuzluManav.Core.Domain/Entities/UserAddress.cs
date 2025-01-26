using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class UserAddress : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; } = string.Empty;
    public virtual User User { get; set; } = null!;
    public virtual City City { get; set; } = null!;
    public virtual District District { get; set; } = null!;
}