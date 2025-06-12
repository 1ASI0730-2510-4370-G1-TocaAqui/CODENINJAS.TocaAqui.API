using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;

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
