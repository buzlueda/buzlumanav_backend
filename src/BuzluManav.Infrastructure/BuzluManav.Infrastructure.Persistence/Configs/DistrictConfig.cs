using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class DistrictConfig : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts").HasKey(x => x.Id).HasName("PK_Districts");

        builder.Property(x => x.Id).HasColumnName("DistrictId");
        builder.Property(x => x.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.UserAddresses)
        .WithOne(x => x.District)
        .HasForeignKey(x => x.DistrictId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
