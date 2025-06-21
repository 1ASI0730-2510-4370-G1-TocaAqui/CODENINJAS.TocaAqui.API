using CODENINJAS.TocaAqui.API.Profile.Domain.Model.ValueObjects;
using CODENINJAS.TocaAqui.API.Profile.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.Profile.Infrastructure.Persistence.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly ApplicationDbContext _context;

    public ProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile?> GetByIdAsync(int id)
    {
        return await _context.Profiles.FindAsync(id);
    }

    public async Task<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile?> GetByEmailAsync(Email email)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(p => p.Email.Value == email.Value);
    }

    public async Task<IEnumerable<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile>> GetAllAsync()
    {
        return await _context.Profiles.ToListAsync();
    }

    public async Task AddAsync(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile)
    {
        await _context.Profiles.AddAsync(profile);
    }

    public async Task UpdateAsync(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile)
    {
        _context.Profiles.Update(profile);
    }

    public async Task<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile?> FindByIdAsync(int id)
    {
        return await _context.Profiles.FindAsync(id);
    }

    public async Task SaveAsync(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile)
    {
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}