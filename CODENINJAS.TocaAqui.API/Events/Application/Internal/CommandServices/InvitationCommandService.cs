using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Application.Internal.CommandServices;

/// <summary>
///     Invitation command service implementation
/// </summary>
public class InvitationCommandService : IInvitationCommandService
{
    private readonly IInvitationRepository _invitationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InvitationCommandService(IInvitationRepository invitationRepository, IUnitOfWork unitOfWork)
    {
        _invitationRepository = invitationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Invitation?> Handle(CreateInvitationCommand command)
    {
        var invitation = new Invitation(command);
        
        try
        {
            await _invitationRepository.AddAsync(invitation);
            await _unitOfWork.CompleteAsync();
            return invitation;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating invitation: {ex.Message}");
            return null;
        }
    }

    public async Task<Invitation?> AcceptInvitation(int invitationId)
    {
        var existingInvitation = await _invitationRepository.FindByIdAsync(invitationId);
        if (existingInvitation == null) return null;

        try
        {
            existingInvitation.Accept();
            _invitationRepository.Update(existingInvitation);
            await _unitOfWork.CompleteAsync();
            return existingInvitation;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accepting invitation: {ex.Message}");
            return null;
        }
    }

    public async Task<Invitation?> RejectInvitation(int invitationId)
    {
        var existingInvitation = await _invitationRepository.FindByIdAsync(invitationId);
        if (existingInvitation == null) return null;

        try
        {
            existingInvitation.Reject();
            _invitationRepository.Update(existingInvitation);
            await _unitOfWork.CompleteAsync();
            return existingInvitation;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error rejecting invitation: {ex.Message}");
            return null;
        }
    }

    public async Task<Invitation?> RespondToInvitation(int invitationId, string status)
    {
        var existingInvitation = await _invitationRepository.FindByIdAsync(invitationId);
        if (existingInvitation == null) return null;

        try
        {
            existingInvitation.UpdateStatus(status);
            _invitationRepository.Update(existingInvitation);
            await _unitOfWork.CompleteAsync();
            return existingInvitation;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating invitation status: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteInvitation(int invitationId)
    {
        var existingInvitation = await _invitationRepository.FindByIdAsync(invitationId);
        if (existingInvitation == null) return false;

        try
        {
            _invitationRepository.Remove(existingInvitation);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting invitation: {ex.Message}");
            return false;
        }
    }
} 
