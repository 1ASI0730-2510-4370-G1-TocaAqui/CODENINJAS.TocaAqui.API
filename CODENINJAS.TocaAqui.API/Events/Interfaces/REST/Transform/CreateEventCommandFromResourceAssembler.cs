using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform CreateEventResource to CreateEventCommand
/// </summary>
public static class CreateEventCommandFromResourceAssembler
{
    /// <summary>
    ///     Transform CreateEventResource to CreateEventCommand
    /// </summary>
    /// <param name="resource">The CreateEventResource</param>
    /// <returns>The CreateEventCommand</returns>
    public static CreateEventCommand ToCommandFromResource(CreateEventResource resource)
    {
        return new CreateEventCommand(
            resource.PromoterId,
            resource.Name,
            resource.Date,
            TimeSpan.Parse(resource.Time),
            resource.PublishDate,
            resource.Location,
            resource.ImageUrl,
            resource.Status,
            resource.SoundcheckDate,
            !string.IsNullOrEmpty(resource.SoundcheckTime) ? TimeSpan.Parse(resource.SoundcheckTime) : null,
            resource.Capacity,
            resource.AvailableTickets,
            resource.AdminName,
            resource.AdminId,
            resource.AdminContact,
            resource.Requirements,
            resource.Description,
            resource.Payment,
            resource.Duration,
            resource.Genre,
            resource.Equipment
        );
    }
} 
