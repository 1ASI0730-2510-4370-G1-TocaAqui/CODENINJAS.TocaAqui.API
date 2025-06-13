using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
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
            entity.ArtistId,
            entity.PromoterId,
            entity.Status,
            entity.CreatedAt,
            entity.Message
        );
    }
} 
