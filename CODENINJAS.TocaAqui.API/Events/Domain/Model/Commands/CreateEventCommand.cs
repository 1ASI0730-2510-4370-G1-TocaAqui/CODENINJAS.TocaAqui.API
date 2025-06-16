namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

/// <summary>
///     Command to create a new event
/// </summary>
/// <param name="PromoterId">The promoter ID</param>
/// <param name="Name">The event name</param>
/// <param name="Date">The event date</param>
/// <param name="Time">The event time</param>
/// <param name="PublishDate">The publish date</param>
/// <param name="Location">The event location</param>
/// <param name="ImageUrl">The event image URL</param>
/// <param name="Status">The event status</param>
/// <param name="SoundcheckDate">The soundcheck date</param>
/// <param name="SoundcheckTime">The soundcheck time</param>
/// <param name="Capacity">The event capacity</param>
/// <param name="AdminName">The admin name</param>
/// <param name="AdminId">The admin ID</param>
/// <param name="AdminContact">The admin contact</param>
/// <param name="Requirements">The event requirements</param>
/// <param name="Description">The event description</param>
/// <param name="Payment">The payment amount</param>
/// <param name="Duration">The event duration</param>
/// <param name="Genre">The music genre</param>
/// <param name="Equipment">The equipment details</param>
public record CreateEventCommand(
    int? PromoterId,
    string Name,
    DateTime Date,
    string Time,
    DateTime PublishDate,
    string Location,
    string ImageUrl,
    string Status,
    DateTime? SoundcheckDate,
    string? SoundcheckTime,
    int Capacity,
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
