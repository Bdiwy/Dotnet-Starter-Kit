using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
namespace Domain.Entities
{

    public class Role : ITenantEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid TenantId { get; set; }
        [Required, StringLength(100)]
        public required string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }


        public enum COFOUNDERS
        {
            OWNER,
            CEO,
            FOUNDER,
        }
    }
}
