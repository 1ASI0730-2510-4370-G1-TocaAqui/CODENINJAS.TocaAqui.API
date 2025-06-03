using Microsoft.EntityFrameworkCore;
using tocaaqui_backend.Domain.Users.Entities;
using tocaaqui_backend.Domain.Users.Interfaces;
using tocaaqui_backend.Infrastructure.Persistence;

namespace tocaaqui_backend.Infrastructure.Repositories;

public class EfUserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public EfUserRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync(ct);
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken ct = default) =>
        _db.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Value == email, ct);

    public Task<bool> ExistsEmailAsync(string email, CancellationToken ct = default) =>
        _db.Users.AnyAsync(u => u.Email.Value == email, ct);
}
