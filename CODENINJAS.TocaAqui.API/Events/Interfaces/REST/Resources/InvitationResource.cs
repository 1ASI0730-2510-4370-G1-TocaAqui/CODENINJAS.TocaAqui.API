namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for invitations
/// </summary>
public record InvitationResource(
    int Id,
    int EventId,
    int ArtistId,
    int PromoterId,
    string Status,
    DateTime CreatedAt,
    string Message
); 
