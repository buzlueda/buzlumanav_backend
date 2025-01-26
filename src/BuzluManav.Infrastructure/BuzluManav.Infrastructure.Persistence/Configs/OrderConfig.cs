using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(x => x.Id).HasName("PK_Orders");

        builder.Property(x => x.Id).HasColumnName("OrderId");
        builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(x => x.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(x => x.DeliveryDate).HasColumnName("DeliveryDate");
        builder.Property(x => x.OrderStatusId).HasColumnName("Status").IsRequired();
        builder.Property(x => x.TotalPrice).HasColumnName("TotalPrice").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.OrderItems)
        .WithOne(x => x.Order)
        .HasForeignKey(x => x.OrderId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
