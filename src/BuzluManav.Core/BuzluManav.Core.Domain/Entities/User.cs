using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string TCNO { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public int? UserAddressId { get; set; }
    public string ProfilePhotoUrl { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public bool IsActive { get; set; }
    public int OperationClaimId { get; set; }

    public virtual OperationClaim OperationClaim { get; set; } = null!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new HashSet<UserAddress>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<UserFavoriteItem> UserFavoriteItems { get; set; } = new HashSet<UserFavoriteItem>();
}   