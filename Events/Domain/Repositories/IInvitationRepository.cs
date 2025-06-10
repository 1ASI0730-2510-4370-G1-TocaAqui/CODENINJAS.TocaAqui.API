using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Shared.Domain.Repositories;

namespace tocaaqui_backend.Events.Domain.Repositories;

/// <summary>
///     Repository interface for Invitation aggregate
/// </summary>
public interface IInvitationRepository : IBaseRepository<Invitation>
{
    Task<IEnumerable<Invitation>> FindByArtistIdAsync(int artistId);
    Task<IEnumerable<Invitation>> FindByPromoterIdAsync(int promoterId);
    Task<IEnumerable<Invitation>> FindByEventIdAsync(int eventId);
} 
