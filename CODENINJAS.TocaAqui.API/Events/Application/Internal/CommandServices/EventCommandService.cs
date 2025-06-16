using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Application.Internal.CommandServices;

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
            existingEvent.Update(command);
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
