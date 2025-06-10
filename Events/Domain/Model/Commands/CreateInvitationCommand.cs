namespace tocaaqui_backend.Events.Domain.Model.Commands;

/// <summary>
///     Command to create an invitation from promoter to musician
/// </summary>
/// <param name="EventId">The ID of the event</param>
/// <param name="EventName">The name of the event</param>
/// <param name="EventDate">The date of the event</param>
/// <param name="EventLocation">The location of the event</param>
/// <param name="EventImageUrl">The image URL of the event</param>
/// <param name="PromoterId">The ID of the promoter sending the invitation</param>
/// <param name="PromoterName">The name of the promoter</param>
/// <param name="ArtistId">The ID of the artist being invited</param>
/// <param name="ArtistName">The name of the artist</param>
/// <param name="Message">The invitation message</param>
/// <param name="Status">The status of the invitation</param>
public record CreateInvitationCommand(
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
    string Status
); 
