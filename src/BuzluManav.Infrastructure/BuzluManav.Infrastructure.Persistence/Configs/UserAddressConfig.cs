using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses").HasKey(x => x.Id).HasName("PK_UserAddresses");

        builder.Property(x => x.Id).HasColumnName("UserAddressId");
        builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(x => x.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(x => x.DistrictId).HasColumnName("DistrictId").IsRequired();
        builder.Property(x => x.Address).HasColumnName("Address").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
    }
}
