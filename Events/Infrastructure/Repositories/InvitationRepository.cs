using Microsoft.EntityFrameworkCore;
using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Repositories;
using tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace tocaaqui_backend.Events.Infrastructure.Repositories;

/// <summary>
///     Invitation repository implementation
/// </summary>
public class InvitationRepository : BaseRepository<Invitation>, IInvitationRepository
{
    public InvitationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Invitation>> FindByArtistIdAsync(int artistId)
    {
        return await Context.Set<Invitation>()
            .Where(i => i.ArtistId == artistId)
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invitation>> FindByPromoterIdAsync(int promoterId)
    {
        return await Context.Set<Invitation>()
            .Where(i => i.PromoterId == promoterId)
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invitation>> FindByEventIdAsync(int eventId)
    {
        return await Context.Set<Invitation>()
            .Where(i => i.EventId == eventId)
            .ToListAsync();
    }
} 
