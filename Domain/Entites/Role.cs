using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{

    public class Role {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, StringLength(100)]
        public required string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }


        public enum CFOUNDERS
        {
            OWNER,
            CEO,
            FOUNDER,
        }
    }
}
