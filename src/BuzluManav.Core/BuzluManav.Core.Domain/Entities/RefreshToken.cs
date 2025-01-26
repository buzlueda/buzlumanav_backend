using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class RefreshToken : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string CreatedByIp { get; set; } = string.Empty;
    public DateTime? RevokedDate { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }


    public virtual User User { get; set; } = null!;
}