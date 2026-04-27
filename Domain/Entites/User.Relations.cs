namespace Domain.Entities
{
    public partial class User
    {
        public virtual ICollection<Client> Clients { get; set; } = new HashSet<Client>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public IEnumerable<string> Permissions => 
            Role?.RolePermissions?.Select(rp => rp.Permission.Name) ?? new List<string>();

        public virtual ICollection<AccessAndRefreshToken> Tokens { get; set; } = new HashSet<AccessAndRefreshToken>();
    }
}
