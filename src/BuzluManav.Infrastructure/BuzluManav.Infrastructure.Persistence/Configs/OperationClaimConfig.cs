using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class OperationClaimConfig : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(x => x.Id).HasName("PK_OperationClaims");

        builder.Property(x => x.Id).HasColumnName("OperationClaimId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.Users)
        .WithOne(x => x.OperationClaim)
        .HasForeignKey(x => x.OperationClaimId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new OperationClaim { Id = 1, Name = "Admin", CreatedAt = DateTime.Now },
            new OperationClaim { Id = 2, Name = "Customer", CreatedAt = DateTime.Now }
        );

    }
}
