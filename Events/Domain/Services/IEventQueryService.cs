using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Model.Queries;

namespace tocaaqui_backend.Events.Domain.Services;

/// <summary>
///     Event query service interface for handling event-related queries
/// </summary>
public interface IEventQueryService
{
    Task<IEnumerable<Event>> Handle(GetEventsByPromoterIdQuery query);
    Task<Event?> Handle(GetEventByIdQuery query);
    Task<IEnumerable<Event>> GetAllEventsAsync();
} 
