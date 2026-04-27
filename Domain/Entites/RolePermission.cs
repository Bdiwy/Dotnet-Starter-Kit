using Domain.Interfaces;

namespace Domain.Entities
{
    public class RolePermission: ITenantEntity
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;

        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; } = null!;

        public Guid TenantId {get; set;}
    }
}