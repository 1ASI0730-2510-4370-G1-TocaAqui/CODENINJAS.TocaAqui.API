namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

/// <summary>
///     Command to create a new RiderTechnical
/// </summary>
public class CreateRiderTechnicalCommand
{
    public int EventApplicationId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
} 
