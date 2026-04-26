using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Client : ITenantEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(100)]
        public required string CompanyName { get; set; } 
        [Required, StringLength(100)]
        public required string ContactName { get; set; } 
        [Required, StringLength(100)]
        public required string ContactEmail { get; set; } 
        [Required, StringLength(100)]
        public required string ContactPhone { get; set; } 
        [Required, StringLength(255)]
        public required string ContactAddress { get; set; }     
        [Required, StringLength(255)]
        public required string TradeLicenseNumber { get; set; }
        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public Guid AddedById { get; set; }
        public virtual required User AddedBy { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}