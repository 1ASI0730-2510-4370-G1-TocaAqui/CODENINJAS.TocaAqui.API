using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform CreateInvitationResource to CreateInvitationCommand
/// </summary>
public static class CreateInvitationCommandFromResourceAssembler
{
    /// <summary>
    ///     Transform CreateInvitationResource to CreateInvitationCommand
    /// </summary>
    /// <param name="resource">The CreateInvitationResource</param>
    /// <returns>The CreateInvitationCommand</returns>
    public static CreateInvitationCommand ToCommandFromResource(CreateInvitationResource resource)
    {
        return new CreateInvitationCommand(
            resource.EventId,
            "Event Name", // EventName - placeholder
            DateTime.UtcNow.AddDays(30), // EventDate - placeholder
            "Event Location", // EventLocation - placeholder
            "", // EventImageUrl - placeholder
            resource.PromoterId,
            "Promoter Name", // PromoterName - placeholder
            resource.ArtistId,
            "Artist Name", // ArtistName - placeholder
            resource.Message,
            "Pending" // Status - debe ser "Pending" con P mayúscula
        );
    }
} 
