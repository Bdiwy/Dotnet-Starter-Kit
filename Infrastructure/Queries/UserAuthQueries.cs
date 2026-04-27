using Application.Interfaces.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries;

public class UserAuthQueries(ApplicationDbContext context) : IUserAuthQueries
{
    private IQueryable<User> UsersWithAuthGraph()
        => context.Users
            .AsSplitQuery()
            .Include(u => u.Role)
            .ThenInclude(r => r.RolePermissions)
            .ThenInclude(rp => rp.Permission);

    public Task<User?> GetByEmailWithRoleAsync(string email, CancellationToken cancellationToken = default)
        => UsersWithAuthGraph()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public Task<User?> GetByIdWithRoleAsync(Guid id, CancellationToken cancellationToken = default)
        => UsersWithAuthGraph()
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
}
