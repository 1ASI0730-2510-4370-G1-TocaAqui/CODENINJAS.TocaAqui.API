using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Interfaces.REST.Resources;

namespace tocaaqui_backend.Events.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform EventApplicant entity to EventApplicantResource
/// </summary>
public static class EventApplicantResourceFromEntityAssembler
{
    /// <summary>
    ///     Transform EventApplicant entity to EventApplicantResource
    /// </summary>
    /// <param name="entity">The EventApplicant entity</param>
    /// <returns>The EventApplicantResource</returns>
    public static EventApplicantResource ToResourceFromEntity(EventApplicant entity)
    {
        return new EventApplicantResource(
            entity.Id,
            entity.UserId,
            entity.EventId,
            entity.Status,
            entity.ApplicationDate,
            entity.ContractSigned,
            entity.RiderUploaded,
            entity.IsInvited
        );
    }
} 
