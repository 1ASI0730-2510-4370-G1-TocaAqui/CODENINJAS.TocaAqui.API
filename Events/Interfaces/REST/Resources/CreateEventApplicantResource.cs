namespace tocaaqui_backend.Events.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a new event application
/// </summary>
public record CreateEventApplicantResource(
    int UserId,
    int EventId,
    string Status = "pending",
    bool IsInvited = false
); 
