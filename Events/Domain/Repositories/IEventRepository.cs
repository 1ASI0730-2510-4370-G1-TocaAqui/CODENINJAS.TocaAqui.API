using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Shared.Domain.Repositories;

namespace tocaaqui_backend.Events.Domain.Repositories;

/// <summary>
///     Repository interface for Event aggregate
/// </summary>
public interface IEventRepository : IBaseRepository<Event>
{
    Task<IEnumerable<Event>> FindByPromoterIdAsync(int promoterId);
    Task<Event?> FindByIdWithDetailsAsync(int id);
} 
