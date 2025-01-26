using BuzluManav.Core.Domain.Entities;
using Elasticsearch.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuzluManav.Infrastructure.Persistence.Configs;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(x => x.Id).HasName("PK_RefreshTokens");

        builder.Property(x => x.Id).HasColumnName("RefreshTokenId");
        builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(x => x.Token).HasColumnName("Token").IsRequired();
        builder.Property(x => x.ExpirationDate).HasColumnName("ExpirationDate").IsRequired();
        builder.Property(x => x.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(x => x.RevokedDate).HasColumnName("RevokedDate");
        builder.Property(x => x.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(x => x.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(x => x.ReasonRevoked).HasColumnName("ReasonRevoked");

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
    }
}
