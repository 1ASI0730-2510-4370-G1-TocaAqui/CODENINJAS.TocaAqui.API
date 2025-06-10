namespace tocaaqui_backend.Events.Domain.Model.Commands;

/// <summary>
///     Command to create an event application (musician applying to an event)
/// </summary>
/// <param name="UserId">The ID of the user applying</param>
/// <param name="EventId">The ID of the event being applied to</param>
/// <param name="Status">The initial status of the application</param>
/// <param name="ApplicationDate">The date when the application was submitted</param>
/// <param name="ContractSigned">Whether the contract has been signed</param>
/// <param name="RiderUploaded">Whether the technical rider has been uploaded</param>
/// <param name="IsInvited">Whether this application comes from an invitation</param>
public record CreateEventApplicantCommand(
    int UserId,
    int EventId,
    string Status,
    DateTime ApplicationDate,
    bool ContractSigned,
    bool RiderUploaded,
    bool IsInvited
); 
