using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Shared.Domain.Repositories;

namespace tocaaqui_backend.Events.Domain.Repositories;

/// <summary>
///     Repository interface for EventApplicant aggregate
/// </summary>
public interface IEventApplicantRepository : IBaseRepository<EventApplicant>
{
    Task<IEnumerable<EventApplicant>> FindByEventIdAsync(int eventId);
    Task<IEnumerable<EventApplicant>> FindByUserIdAsync(int userId);
    Task<EventApplicant?> FindByEventIdAndUserIdAsync(int eventId, int userId);
} 
