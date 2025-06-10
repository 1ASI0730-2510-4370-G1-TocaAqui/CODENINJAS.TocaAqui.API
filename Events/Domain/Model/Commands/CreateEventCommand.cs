namespace tocaaqui_backend.Events.Domain.Model.Commands;

/// <summary>
///     Command to create a new musical event
/// </summary>
/// <param name="PromoterId">The ID of the promoter creating the event</param>
/// <param name="Name">The name of the event</param>
/// <param name="Date">The date when the event will take place</param>
/// <param name="Time">The time when the event will start</param>
/// <param name="PublishDate">The date when the event was published</param>
/// <param name="Location">The location where the event will take place</param>
/// <param name="ImageUrl">The URL of the event image</param>
/// <param name="Status">The current status of the event</param>
/// <param name="SoundcheckDate">The date for soundcheck</param>
/// <param name="SoundcheckTime">The time for soundcheck</param>
/// <param name="Capacity">The maximum capacity of the venue</param>
/// <param name="AvailableTickets">The number of available tickets</param>
/// <param name="AdminName">The name of the event administrator</param>
/// <param name="AdminId">The ID of the event administrator</param>
/// <param name="AdminContact">The contact information of the event administrator</param>
/// <param name="Requirements">The requirements for the event</param>
/// <param name="Description">The description of the event</param>
/// <param name="Payment">The payment amount for the performer</param>
/// <param name="Duration">The duration of the event in minutes</param>
/// <param name="Genre">The musical genre of the event</param>
/// <param name="Equipment">The equipment provided for the event</param>
public record CreateEventCommand(
    int? PromoterId,
    string Name,
    DateTime Date,
    TimeSpan Time,
    DateTime PublishDate,
    string Location,
    string ImageUrl,
    string Status,
    DateTime? SoundcheckDate,
    TimeSpan? SoundcheckTime,
    int Capacity,
    int AvailableTickets,
    string AdminName,
    int? AdminId,
    string AdminContact,
    string Requirements,
    string Description,
    decimal Payment,
    int? Duration,
    string Genre,
    string Equipment
); 
