using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Permission
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(100)]
        public required string Name { get; set; } 
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}