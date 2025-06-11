namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

/// <summary>
///     Event resource for API responses
/// </summary>
public record EventResource(
    int Id,
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
