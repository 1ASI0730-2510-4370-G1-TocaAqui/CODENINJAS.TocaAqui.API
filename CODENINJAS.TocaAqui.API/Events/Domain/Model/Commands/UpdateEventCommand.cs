namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

/// <summary>
///     Command to update an existing musical event
/// </summary>
/// <param name="Name">The name of the event</param>
/// <param name="Date">The date when the event will take place</param>
/// <param name="Time">The time when the event will start</param>
/// <param name="Location">The location where the event will take place</param>
/// <param name="Description">The description of the event</param>
/// <param name="Requirements">The requirements for the event</param>
/// <param name="Payment">The payment amount for the performer</param>
/// <param name="Genre">The musical genre of the event</param>
/// <param name="Equipment">The equipment provided for the event</param>
/// <param name="Capacity">The maximum capacity of the venue</param>
/// <param name="AvailableTickets">The number of available tickets</param>
public record UpdateEventCommand(
    string Name,
    DateTime Date,
    TimeSpan Time,
    string Location,
    string Description,
    string Requirements,
    decimal Payment,
    string Genre,
    string Equipment,
    int Capacity,
    int AvailableTickets
); 
