using Microsoft.EntityFrameworkCore;
using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Repositories;
using tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace tocaaqui_backend.Events.Infrastructure.Repositories;

/// <summary>
///     Event repository implementation
/// </summary>
public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Event>> FindByPromoterIdAsync(int promoterId)
    {
        return await Context.Set<Event>()
            .Where(e => e.PromoterId == promoterId)
            .ToListAsync();
    }

    public async Task<Event?> FindByIdWithDetailsAsync(int id)
    {
        return await Context.Set<Event>()
            .FirstOrDefaultAsync(e => e.Id == id);
    }
} 
