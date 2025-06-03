namespace tocaaqui_backend.Domain.Users.Interfaces;

using tocaaqui_backend.Domain.Users.Entities;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct = default);
    Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
    Task<bool> ExistsEmailAsync(string email, CancellationToken ct = default);
}
