namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for invitations
/// </summary>
public record InvitationResource(
    int Id,
    int EventId,
    string EventName,
    DateTime EventDate,
    string EventLocation,
    string EventImageUrl,
    int ArtistId,
    string ArtistName,
    int PromoterId,
    string PromoterName,
    string Status,
    DateTime CreatedAt,
    string Message
); 
