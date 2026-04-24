using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class User : ITenantEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid TenantId { get; set; }
        
        /// <summary>
        /// Indicates if the user is the owner of the tenant
        /// </summary>
        public bool IsOwner { get; set; } = false;
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }

        [Required, StringLength(100)]
        public required string Username { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        [Required, EmailAddress, StringLength(256)]
        public required string Email { get; set; }

        [Required, Phone, StringLength(20)]
        public required string PhoneNumber { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public virtual required Role Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}