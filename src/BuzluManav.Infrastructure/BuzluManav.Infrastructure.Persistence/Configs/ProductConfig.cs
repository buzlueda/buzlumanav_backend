using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(x => x.Id).HasName("PK_Products");

        builder.Property(x => x.Id).HasColumnName("ProductId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
        builder.Property(x => x.Price).HasColumnName("Price").IsRequired();
        builder.Property(x => x.Stock).HasColumnName("Stock").IsRequired();
        builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(x => x.CategoryId).HasColumnName("CategoryId").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.BasketItems)
        .WithOne(x => x.Product)
        .HasForeignKey(x => x.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.OrderItems)
        .WithOne(x => x.Product)
        .HasForeignKey(x => x.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
