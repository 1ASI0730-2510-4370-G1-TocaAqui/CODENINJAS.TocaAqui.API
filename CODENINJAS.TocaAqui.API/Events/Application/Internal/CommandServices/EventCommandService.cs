using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Application.Internal.CommandServices;

/// <summary>
///     Service to handle event commands
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
        await _eventRepository.AddAsync(eventEntity);
        await _unitOfWork.CompleteAsync();
        return eventEntity;
    }

    public async Task<Event?> Handle(UpdateEventCommand command, int eventId)
    {
        var existingEvent = await _eventRepository.FindByIdAsync(eventId);
        if (existingEvent == null)
            return null;

        existingEvent.UpdateEvent(command);
        _eventRepository.Update(existingEvent);
        await _unitOfWork.CompleteAsync();
        return existingEvent;
    }

    public async Task<bool> Handle(int id)
    {
        var eventEntity = await _eventRepository.FindByIdAsync(id);
        
        if (eventEntity is null) 
            return false;
        
        _eventRepository.Remove(eventEntity);
        await _unitOfWork.CompleteAsync();
        return true;
    }
} 
