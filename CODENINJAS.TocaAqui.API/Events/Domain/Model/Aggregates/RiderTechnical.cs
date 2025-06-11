using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;

/// <summary>
///     RiderTechnical Aggregate - Represents a technical rider document for an event
/// </summary>
public partial class RiderTechnical
{
    protected RiderTechnical()
    {
        FilePath = string.Empty;
        UploadDate = DateTime.UtcNow;
    }

    /// <summary>
    ///     Constructor for the RiderTechnical aggregate.
    /// </summary>
    /// <param name="command">The CreateRiderTechnicalCommand</param>
    public RiderTechnical(CreateRiderTechnicalCommand command)
    {
        EventApplicationId = command.EventApplicationId;
        FilePath = command.FilePath;
        UploadDate = command.UploadDate;
    }

    // Properties
    public int Id { get; }
    public int EventApplicationId { get; private set; }
    public string FilePath { get; private set; }
    public DateTime UploadDate { get; private set; }

    // Domain methods
    public void UpdateFilePath(string filePath)
    {
        FilePath = filePath;
        UploadDate = DateTime.UtcNow;
    }
} 
