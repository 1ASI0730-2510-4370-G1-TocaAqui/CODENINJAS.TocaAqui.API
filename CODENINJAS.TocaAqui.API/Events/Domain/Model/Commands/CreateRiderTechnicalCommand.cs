namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

/// <summary>
///     Command to create a technical rider for an event application
/// </summary>
/// <param name="EventApplicationId">The ID of the event application</param>
/// <param name="FilePath">The path to the rider file</param>
/// <param name="UploadDate">The date when the rider was uploaded</param>
public record CreateRiderTechnicalCommand(
    int EventApplicationId,
    string FilePath,
    DateTime UploadDate
); 
