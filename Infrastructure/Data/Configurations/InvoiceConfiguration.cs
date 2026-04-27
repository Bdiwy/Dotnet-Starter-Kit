namespace Infrastructure.Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");
        builder.HasKey(i => i.Id);
        builder.HasOne(i => i.AddedBy)
            .WithMany(u => u.Invoices)
            .HasForeignKey(i => i.AddedById);

        builder.HasOne(i => i.Client)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(i => i.Status)
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(i => i.PaymentMethod)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasIndex(i => new { i.TenantId, i.AddedById })
            .HasDatabaseName("IX_Invoices_Tenant_AddedBy");
        
        builder.HasIndex(i => new { i.TenantId, i.PaymentMethod })
            .HasDatabaseName("IX_Invoices_Tenant_PaymentMethod");

        builder.HasIndex(i => new { i.TenantId, i.Status })
            .HasDatabaseName("IX_Invoices_Tenant_Status");
    }
}