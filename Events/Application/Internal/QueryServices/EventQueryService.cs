using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Model.Queries;
using tocaaqui_backend.Events.Domain.Repositories;
using tocaaqui_backend.Events.Domain.Services;

namespace tocaaqui_backend.Events.Application.Internal.QueryServices;

/// <summary>
///     Event query service implementation
/// </summary>
public class EventQueryService : IEventQueryService
{
    private readonly IEventRepository _eventRepository;

    public EventQueryService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<Event>> Handle(GetEventsByPromoterIdQuery query)
    {
        return await _eventRepository.FindByPromoterIdAsync(query.PromoterId);
    }

    public async Task<Event?> Handle(GetEventByIdQuery query)
    {
        return await _eventRepository.FindByIdWithDetailsAsync(query.Id);
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _eventRepository.ListAsync();
    }
} 
