using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Services;

/// <summary>
///     Event command service interface for handling event-related commands
/// </summary>
public interface IEventCommandService
{
    Task<Event?> Handle(CreateEventCommand command);
    Task<Event?> Handle(UpdateEventCommand command, int eventId);
    Task<bool> Handle(int eventId);
} 
