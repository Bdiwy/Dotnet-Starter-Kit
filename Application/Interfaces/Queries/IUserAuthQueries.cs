using Domain.Entities;

namespace Application.Interfaces.Queries;

public interface IUserAuthQueries
{
    Task<User?> GetByEmailWithRoleAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetByIdWithRoleAsync(Guid id, CancellationToken cancellationToken = default);
}
