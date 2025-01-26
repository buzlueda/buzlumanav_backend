using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems").HasKey(x => x.Id).HasName("PK_OrderItems");

        builder.Property(x => x.Id).HasColumnName("OrderItemId");
        builder.Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
        builder.Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(x => x.Price).HasColumnName("Price").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
    }
}
