using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class UserFavoriteItemConfig : IEntityTypeConfiguration<UserFavoriteItem>
{
    public void Configure(EntityTypeBuilder<UserFavoriteItem> builder)
    {
        builder.ToTable("UserFavoriteItems").HasKey(x => x.Id).HasName("PK_UserFavoriteItems");

        builder.Property(x => x.Id).HasColumnName("UserFavoriteItemId");
        builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
    }
}
