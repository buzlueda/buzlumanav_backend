using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class OrderStatusConfig : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.ToTable("OrderStatuses").HasKey(x => x.Id).HasName("PK_OrderStatuses");

        builder.Property(x => x.Id).HasColumnName("OrderStatusId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.Orders)
        .WithOne(x => x.OrderStatus)
        .HasForeignKey(x => x.OrderStatusId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new OrderStatus { Id = 1, Name = "Pending", CreatedAt = DateTime.Now },
            new OrderStatus { Id = 2, Name = "Preparing", CreatedAt = DateTime.Now },
            new OrderStatus { Id = 3, Name = "OnTheWay", CreatedAt = DateTime.Now },
            new OrderStatus { Id = 4, Name = "Delivered", CreatedAt = DateTime.Now },
            new OrderStatus { Id = 5, Name = "Canceled", CreatedAt = DateTime.Now }
        );
    }
}
