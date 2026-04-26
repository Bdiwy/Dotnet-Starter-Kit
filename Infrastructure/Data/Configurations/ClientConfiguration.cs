namespace Infrastructure.Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.AddedBy)
            .WithMany(u => u.Clients)
            .HasForeignKey(c => c.AddedById);

        builder.HasMany(c => c.Invoices)
            .WithOne(i => i.Client)
            .HasForeignKey(i => i.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}