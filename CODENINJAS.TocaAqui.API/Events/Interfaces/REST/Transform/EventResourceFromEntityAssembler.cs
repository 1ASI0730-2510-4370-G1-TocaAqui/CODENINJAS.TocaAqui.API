using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
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
            entity.EventTime.Date,
            entity.EventTime.Time.ToString(@"hh\:mm"),
            entity.PublishDate,
            entity.Location,
            entity.ImageUrl,
            entity.Status.ToString(),
            entity.SoundcheckTime.Date,
            entity.SoundcheckTime.Time.ToString(@"hh\:mm"),
            entity.Capacity,
            entity.AvailableTickets,
            entity.Admin.Name,
            entity.Admin.Id,
            entity.Admin.Contact,
            entity.Requirements,
            entity.Description,
            entity.Payment.Amount,
            entity.Duration,
            entity.Genre.ToString(),
            entity.Equipment
        );
    }
} 
