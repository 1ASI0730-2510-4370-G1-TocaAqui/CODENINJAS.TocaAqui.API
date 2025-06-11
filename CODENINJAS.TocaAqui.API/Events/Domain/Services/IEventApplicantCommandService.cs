using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Services;

/// <summary>
///     EventApplicant command service interface for handling application-related commands
/// </summary>
public interface IEventApplicantCommandService
{
    Task<EventApplicant?> Handle(CreateEventApplicantCommand command);
    Task<EventApplicant?> UpdateApplicationStatus(int applicantId, string status);
    Task<bool> DeleteApplication(int applicantId);
} 
