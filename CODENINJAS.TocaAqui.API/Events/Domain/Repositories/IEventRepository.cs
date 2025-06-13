using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Repositories;

/// <summary>
///     Repository interface for Event aggregate
/// </summary>
public interface IEventRepository : IBaseRepository<Event>
{
    Task<IEnumerable<Event>> FindByPromoterIdAsync(int promoterId);
    Task<Event?> FindByIdWithDetailsAsync(int id);
} 
