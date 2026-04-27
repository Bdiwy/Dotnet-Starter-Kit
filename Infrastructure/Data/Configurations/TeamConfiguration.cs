using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.HasIndex(t => new { t.Name, t.TenantId }).IsUnique();

            builder.HasMany(t => t.Users)
                    .WithOne(u => u.Team)
                    .HasForeignKey(u => u.TeamId)
                    .OnDelete(DeleteBehavior.SetNull); 

            builder.HasIndex(i => new { i.TenantId, i.Name })
                .HasDatabaseName("IX_Team_Tenant_Name");
            }
    }
}