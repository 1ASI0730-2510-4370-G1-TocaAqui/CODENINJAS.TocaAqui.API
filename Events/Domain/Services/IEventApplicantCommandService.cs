using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Model.Commands;

namespace tocaaqui_backend.Events.Domain.Services;

/// <summary>
///     EventApplicant command service interface for handling application-related commands
/// </summary>
public interface IEventApplicantCommandService
{
    Task<EventApplicant?> Handle(CreateEventApplicantCommand command);
    Task<EventApplicant?> UpdateApplicationStatus(int applicantId, string status);
    Task<bool> DeleteApplication(int applicantId);
} 
