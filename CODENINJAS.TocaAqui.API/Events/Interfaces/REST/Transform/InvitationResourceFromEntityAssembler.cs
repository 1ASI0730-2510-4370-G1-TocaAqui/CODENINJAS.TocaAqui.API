using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform Invitation entity to InvitationResource
/// </summary>
public static class InvitationResourceFromEntityAssembler
{
    /// <summary>
    ///     Transform Invitation entity to InvitationResource
    /// </summary>
    /// <param name="entity">The Invitation entity</param>
    /// <returns>The InvitationResource</returns>
    public static InvitationResource ToResourceFromEntity(Invitation entity)
    {
        return new InvitationResource(
            entity.Id,
            entity.EventId,
            entity.EventName,
            entity.EventDate,
            entity.EventLocation,
            entity.EventImageUrl,
            entity.ArtistId,
            entity.ArtistName,
            entity.PromoterId,
            entity.PromoterName,
            entity.Status.ToString(),
            entity.CreatedAt,
            entity.Message
        );
    }
} 
