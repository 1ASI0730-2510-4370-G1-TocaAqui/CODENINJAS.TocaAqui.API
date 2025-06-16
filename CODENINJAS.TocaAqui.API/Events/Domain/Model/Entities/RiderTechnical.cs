using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;

/// <summary>
///     RiderTechnical Entity - Represents the technical requirements for an event
/// </summary>
public class RiderTechnical
{
    protected RiderTechnical()
    {
        Content = string.Empty;
    }

    /// <summary>
    ///     Constructor for the RiderTechnical entity.
    /// </summary>
    /// <param name="command">The CreateRiderTechnicalCommand</param>
    public RiderTechnical(CreateRiderTechnicalCommand command)
    {
        EventApplicationId = command.EventApplicationId;
        Content = command.Content;
    }

    // Properties
    public int Id { get; }
    public int EventApplicationId { get; private set; }
    public string Content { get; private set; }

    // Domain methods
    public void UpdateContent(string content)
    {
        Content = content;
    }
} 