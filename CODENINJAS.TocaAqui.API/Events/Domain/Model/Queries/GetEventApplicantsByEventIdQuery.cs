namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Queries;

/// <summary>
///     Query to get all applicants for a specific event
/// </summary>
/// <param name="EventId">The event ID</param>
public record GetEventApplicantsByEventIdQuery(int EventId); 
