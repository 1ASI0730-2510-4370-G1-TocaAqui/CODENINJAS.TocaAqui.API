namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a new event
/// </summary>
public record CreateEventResource(
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
