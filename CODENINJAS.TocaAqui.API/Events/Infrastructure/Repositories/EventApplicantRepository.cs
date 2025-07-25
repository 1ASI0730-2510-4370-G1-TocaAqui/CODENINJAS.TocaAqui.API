using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;

/// <summary>
///     EventApplicant repository implementation
/// </summary>
public class EventApplicantRepository : BaseRepository<EventApplicant>, IEventApplicantRepository
{
    public EventApplicantRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EventApplicant>> FindByEventIdAsync(int eventId)
    {
        return await Context.Set<EventApplicant>()
            .Where(ea => ea.EventId == eventId)
            .ToListAsync();
    }

    public async Task<IEnumerable<EventApplicant>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<EventApplicant>()
            .Where(ea => ea.UserId == userId)
            .ToListAsync();
    }

    public async Task<EventApplicant?> FindByEventIdAndUserIdAsync(int eventId, int userId)
    {
        return await Context.Set<EventApplicant>()
            .FirstOrDefaultAsync(ea => ea.EventId == eventId && ea.UserId == userId);
    }
} 
