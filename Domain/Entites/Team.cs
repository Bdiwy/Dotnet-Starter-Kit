using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{

    public class Team
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(100)]
        public required string Name { get; set; }

        public Guid TenantId { get; set; } 
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
