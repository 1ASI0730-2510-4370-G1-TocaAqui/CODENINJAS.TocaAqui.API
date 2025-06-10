namespace tocaaqui_backend.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating invitations
/// </summary>
public record CreateInvitationResource(
    int EventId,
    int ArtistId,
    int PromoterId,
    string Message
); 
