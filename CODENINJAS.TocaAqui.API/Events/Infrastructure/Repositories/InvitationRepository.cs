using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;

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
