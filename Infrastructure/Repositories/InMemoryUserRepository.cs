namespace tocaaqui_backend.Infrastructure.Repositories;

using tocaaqui_backend.Domain.Users.Entities;
using tocaaqui_backend.Domain.Users.Interfaces;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public Task AddAsync(User user, CancellationToken ct = default)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken ct = default) =>
        Task.FromResult(_users.FirstOrDefault(u => u.Email.Value == email));

    public Task<bool> ExistsEmailAsync(string email, CancellationToken ct = default) =>
        Task.FromResult(_users.Any(u => u.Email.Value == email));
}
