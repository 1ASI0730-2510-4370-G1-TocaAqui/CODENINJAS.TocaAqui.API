using Microsoft.EntityFrameworkCore;
using tocaaqui_backend.Profile.Domain.Model.ValueObjects;
using tocaaqui_backend.Profile.Domain.Repositories;
using tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace tocaaqui_backend.Profile.Infrastructure.Persistence.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly ApplicationDbContext _context;

    public ProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Model.Aggregates.Profile?> GetByIdAsync(ProfileId id)
    {
        return await _context.Profiles.FindAsync(id.Value);
    }

    public async Task<Domain.Model.Aggregates.Profile?> GetByEmailAsync(Email email)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(p => p.Email.Value == email.Value);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Profile>> GetAllAsync()
    {
        return await _context.Profiles.ToListAsync();
    }

    public async Task AddAsync(Domain.Model.Aggregates.Profile profile)
    {
        await _context.Profiles.AddAsync(profile);
    }

    public async Task UpdateAsync(Domain.Model.Aggregates.Profile profile)
    {
        _context.Profiles.Update(profile);
    }

    public async Task<Domain.Model.Aggregates.Profile?> FindByIdAsync(Guid id)
    {
        return await _context.Profiles.FindAsync(id);
    }

    public async Task SaveAsync(Domain.Model.Aggregates.Profile profile)
    {
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}