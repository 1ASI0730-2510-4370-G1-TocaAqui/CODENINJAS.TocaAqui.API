namespace tocaaqui_backend.Events.Interfaces.REST.Resources;

/// <summary>
///     EventApplicant resource for API responses
/// </summary>
public record EventApplicantResource(
    int Id,
    int UserId,
    int EventId,
    string Status,
    DateTime ApplicationDate,
    bool ContractSigned,
    bool RiderUploaded,
    bool IsInvited
); 
