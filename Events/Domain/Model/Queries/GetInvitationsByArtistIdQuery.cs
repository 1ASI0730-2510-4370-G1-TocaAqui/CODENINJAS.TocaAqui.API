namespace tocaaqui_backend.Events.Domain.Model.Queries;

/// <summary>
///     Query to get all invitations for a specific artist
/// </summary>
/// <param name="ArtistId">The artist ID</param>
public record GetInvitationsByArtistIdQuery(int ArtistId); 
