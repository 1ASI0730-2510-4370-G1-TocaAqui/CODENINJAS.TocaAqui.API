using tocaaqui_backend.Events.Domain.Model.Aggregates;
using tocaaqui_backend.Events.Domain.Model.Commands;
using tocaaqui_backend.Events.Domain.Repositories;
using tocaaqui_backend.Events.Domain.Services;
using tocaaqui_backend.Shared.Domain.Repositories;

namespace tocaaqui_backend.Events.Application.Internal.CommandServices;

/// <summary>
///     Event command service implementation
/// </summary>
public class EventCommandService : IEventCommandService
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EventCommandService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Event?> Handle(CreateEventCommand command)
    {
        var eventEntity = new Event(command);
        
        try
        {
            await _eventRepository.AddAsync(eventEntity);
            await _unitOfWork.CompleteAsync();
            return eventEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating event: {ex.Message}");
            return null;
        }
    }

    public async Task<Event?> Handle(UpdateEventCommand command, int eventId)
    {
        var existingEvent = await _eventRepository.FindByIdAsync(eventId);
        if (existingEvent == null) return null;

        try
        {
            existingEvent.UpdateEvent(command);
            _eventRepository.Update(existingEvent);
            await _unitOfWork.CompleteAsync();
            return existingEvent;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating event: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> Handle(int eventId)
    {
        var existingEvent = await _eventRepository.FindByIdAsync(eventId);
        if (existingEvent == null) return false;

        try
        {
            _eventRepository.Remove(existingEvent);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting event: {ex.Message}");
            return false;
        }
    }
} 
