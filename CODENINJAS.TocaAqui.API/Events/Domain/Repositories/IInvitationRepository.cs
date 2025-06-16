using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Repositories;

/// <summary>
///     Repository interface for Invitation aggregate
/// </summary>
public interface IInvitationRepository : IBaseRepository<Invitation>
{
    Task<IEnumerable<Invitation>> FindByArtistIdAsync(int artistId);
    Task<IEnumerable<Invitation>> FindByPromoterIdAsync(int promoterId);
    Task<IEnumerable<Invitation>> FindByEventIdAsync(int eventId);
} 
