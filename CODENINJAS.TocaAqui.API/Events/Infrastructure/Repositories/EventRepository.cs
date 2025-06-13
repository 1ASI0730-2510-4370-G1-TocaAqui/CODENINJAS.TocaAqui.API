using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;

/// <summary>
///     Event repository implementation
/// </summary>
public class EventRepository : IEventRepository
{
    private readonly AppDbContext _context;

    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> ListAsync()
    {
        return await _context.Set<Event>().ToListAsync();
    }

    public async Task<Event?> FindByIdAsync(int id)
    {
        return await _context.Set<Event>().FindAsync(id);
    }

    public async Task<IEnumerable<Event>> FindByPromoterIdAsync(int promoterId)
    {
        return await _context.Set<Event>()
            .Where(e => e.PromoterId == promoterId)
            .ToListAsync();
    }

    public async Task AddAsync(Event entity)
    {
        await _context.Set<Event>().AddAsync(entity);
    }

    public void Update(Event entity)
    {
        _context.Set<Event>().Update(entity);
    }

    public void Remove(Event entity)
    {
        _context.Set<Event>().Remove(entity);
    }

    public async Task<Event?> FindByIdWithDetailsAsync(int id)
    {
        return await _context.Set<Event>()
            .FirstOrDefaultAsync(e => e.Id == id);
    }
} 
