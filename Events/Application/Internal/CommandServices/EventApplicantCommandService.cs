using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Model.Commands;
using tocaaqui_backend.Events.Domain.Repositories;
using tocaaqui_backend.Events.Domain.Services;
using tocaaqui_backend.Shared.Domain.Repositories;

namespace tocaaqui_backend.Events.Application.Internal.CommandServices;

/// <summary>
///     EventApplicant command service implementation
/// </summary>
public class EventApplicantCommandService : IEventApplicantCommandService
{
    private readonly IEventApplicantRepository _eventApplicantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EventApplicantCommandService(IEventApplicantRepository eventApplicantRepository, IUnitOfWork unitOfWork)
    {
        _eventApplicantRepository = eventApplicantRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EventApplicant?> Handle(CreateEventApplicantCommand command)
    {
        // Check if user already applied to this event
        var existingApplication = await _eventApplicantRepository.FindByEventIdAndUserIdAsync(command.EventId, command.UserId);
        if (existingApplication != null)
        {
            throw new Exception("User has already applied to this event");
        }

        var eventApplicant = new EventApplicant(command);
        
        try
        {
            await _eventApplicantRepository.AddAsync(eventApplicant);
            await _unitOfWork.CompleteAsync();
            return eventApplicant;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating event application: {ex.Message}");
            return null;
        }
    }

    public async Task<EventApplicant?> UpdateApplicationStatus(int applicantId, string status)
    {
        var existingApplicant = await _eventApplicantRepository.FindByIdAsync(applicantId);
        if (existingApplicant == null) return null;

        try
        {
            existingApplicant.UpdateStatus(status);
            
            if (status.ToLower() == "signed")
            {
                existingApplicant.SignContract();
            }
            
            _eventApplicantRepository.Update(existingApplicant);
            await _unitOfWork.CompleteAsync();
            return existingApplicant;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating application status: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteApplication(int applicantId)
    {
        var existingApplicant = await _eventApplicantRepository.FindByIdAsync(applicantId);
        if (existingApplicant == null) return false;

        try
        {
            _eventApplicantRepository.Remove(existingApplicant);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting application: {ex.Message}");
            return false;
        }
    }
} 
