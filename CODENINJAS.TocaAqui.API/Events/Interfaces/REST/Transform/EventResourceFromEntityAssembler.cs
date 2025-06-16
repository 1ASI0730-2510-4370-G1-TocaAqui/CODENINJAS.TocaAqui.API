using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform Event entity to EventResource
/// </summary>
public static class EventResourceFromEntityAssembler
{
    /// <summary>
    ///     Transform Event entity to EventResource
    /// </summary>
    /// <param name="entity">The Event entity</param>
    /// <returns>The EventResource</returns>
    public static EventResource ToResourceFromEntity(Event entity)
    {
        return new EventResource(
            entity.Id,
            entity.PromoterId,
            entity.Name,
            entity.Date,
            entity.Time.ToString(@"hh\:mm\:ss"),
            entity.PublishDate,
            entity.Location,
            entity.ImageUrl,
            entity.Status.ToString().ToLower(),
            entity.SoundcheckDate,
            entity.SoundcheckTime?.ToString(@"hh\:mm\:ss"),
            entity.Capacity,
            entity.AdminName,
            entity.AdminId,
            entity.AdminContact,
            entity.Requirements,
            entity.Description,
            entity.Payment,
            entity.Duration,
            entity.Genre.ToString().ToLower(),
            entity.Equipment
        );
    }
} 
