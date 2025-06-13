namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating invitations
/// </summary>
public record CreateInvitationResource(
    int EventId,
    string EventName,
    DateTime EventDate,
    string EventLocation,
    string EventImageUrl,
    int PromoterId,
    string PromoterName,
    int ArtistId,
    string ArtistName,
    string Message,
    string Status = "pending"
); 
