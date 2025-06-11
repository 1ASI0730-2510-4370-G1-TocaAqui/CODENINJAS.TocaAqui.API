using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Services;

/// <summary>
///     Invitation command service interface for handling invitation-related commands
/// </summary>
public interface IInvitationCommandService
{
    Task<Invitation?> Handle(CreateInvitationCommand command);
    Task<Invitation?> AcceptInvitation(int invitationId);
    Task<Invitation?> RejectInvitation(int invitationId);
    Task<Invitation?> RespondToInvitation(int invitationId, string status);
    Task<bool> DeleteInvitation(int invitationId);
} 
