using BuzluManav.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(x => x.Id).HasName("PK_Users");

        builder.Property(x => x.Id).HasColumnName("UserId");
        builder.Property(x => x.TCNO).HasColumnName("TCNO").IsRequired();
        builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(x => x.FullName).HasColumnName("FullName").IsRequired();
        builder.Property(x => x.Username).HasColumnName("Username").IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
        builder.Property(x => x.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(x => x.UserAddressId).HasColumnName("UserAddressId");
        builder.Property(x => x.ProfilePhotoUrl).HasColumnName("ProfilePhotoUrl").IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.UserAddresses)
        .WithOne(x => x.User)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Orders)
        .WithOne(x => x.User)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.UserFavoriteItems)
        .WithOne(x => x.User)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
