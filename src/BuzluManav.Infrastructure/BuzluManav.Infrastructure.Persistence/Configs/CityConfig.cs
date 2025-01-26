using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(x => x.Id).HasName("PK_Cities");

        builder.Property(x => x.Id).HasColumnName("CityId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.Districts)
        .WithOne(x => x.City)
        .HasForeignKey(x => x.CityId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.UserAddresses)
        .WithOne(x => x.City)
        .HasForeignKey(x => x.CityId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
