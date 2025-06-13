using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Repositories;

/// <summary>
///     Repository interface for EventApplicant aggregate
/// </summary>
public interface IEventApplicantRepository : IBaseRepository<EventApplicant>
{
    Task<IEnumerable<EventApplicant>> FindByEventIdAsync(int eventId);
    Task<IEnumerable<EventApplicant>> FindByUserIdAsync(int userId);
    Task<EventApplicant?> FindByEventIdAndUserIdAsync(int eventId, int userId);
} 
