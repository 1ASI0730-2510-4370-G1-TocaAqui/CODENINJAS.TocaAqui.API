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
            resource.EventName,
            resource.EventDate,
            resource.EventLocation,
            resource.EventImageUrl,
            resource.PromoterId,
            resource.PromoterName,
            resource.ArtistId,
            resource.ArtistName,
            resource.Message,
            resource.Status
        );
    }
} 
