using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Domain.Entities;
public class OperationClaim : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}