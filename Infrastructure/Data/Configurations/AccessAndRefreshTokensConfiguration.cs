namespace Infrastructure.Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class AccessAndRefreshTokensConfiguration : IEntityTypeConfiguration<AccessAndRefreshToken>
{
    public void Configure(EntityTypeBuilder<AccessAndRefreshToken> builder)
    {
        builder.ToTable("access_and_refresh_tokens");

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.User)
                .WithMany(u => u.Tokens) 
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(i => i.RefreshToken).IsUnique();
        
        builder.HasIndex(i => new { i.UserId, i.DeviceType , i.TenantId });

        builder.Ignore(e => e.IsExpired);
        builder.Ignore(e => e.IsActive);

        builder.Property(t => t.Token).IsRequired();
        builder.Property(t => t.RefreshToken).IsRequired().HasMaxLength(256);
        builder.Property(t => t.DeviceType)
        .HasConversion<string>()
        .HasMaxLength(10);
    }
}