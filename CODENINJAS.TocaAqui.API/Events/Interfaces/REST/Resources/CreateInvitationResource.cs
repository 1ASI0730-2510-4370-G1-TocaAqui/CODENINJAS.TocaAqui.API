namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating invitations
/// </summary>
public record CreateInvitationResource(
    int EventId,
    int ArtistId,
    int PromoterId,
    string Message
); 
