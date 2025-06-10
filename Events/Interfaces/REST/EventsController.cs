using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tocaaqui_backend.Events.Domain.Model.Queries;
using tocaaqui_backend.Events.Domain.Services;
using tocaaqui_backend.Events.Interfaces.REST.Resources;
using tocaaqui_backend.Events.Interfaces.REST.Transform;

namespace tocaaqui_backend.Events.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Events")]
public class EventsController : ControllerBase
{
    private readonly IEventQueryService _eventQueryService;
    private readonly IEventCommandService _eventCommandService;

    public EventsController(IEventQueryService eventQueryService, IEventCommandService eventCommandService)
    {
        _eventQueryService = eventQueryService;
        _eventCommandService = eventCommandService;
    }

    /// <summary>
    /// Get all events
    /// </summary>
    /// <returns>List of all events</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all events",
        Description = "Gets all events available in the platform",
        OperationId = "GetAllEvents")]
    [SwaggerResponse(200, "The events were found", typeof(IEnumerable<EventResource>))]
    public async Task<ActionResult<IEnumerable<EventResource>>> GetAllEvents()
    {
        try
        {
            var events = await _eventQueryService.GetAllEventsAsync();
            var resources = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting events: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Get event by ID
    /// </summary>
    /// <param name="id">Event ID</param>
    /// <returns>Event details</returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets an event by ID",
        Description = "Gets an event by its unique identifier",
        OperationId = "GetEventById")]
    [SwaggerResponse(200, "The event was found", typeof(EventResource))]
    [SwaggerResponse(404, "The event was not found")]
    public async Task<ActionResult<EventResource>> GetEventById(int id)
    {
        var getEventByIdQuery = new GetEventByIdQuery(id);
        var eventEntity = await _eventQueryService.Handle(getEventByIdQuery);
        
        if (eventEntity is null) 
            return NotFound();
        
        var resource = EventResourceFromEntityAssembler.ToResourceFromEntity(eventEntity);
        return Ok(resource);
    }

    /// <summary>
    /// Get events by promoter ID
    /// </summary>
    /// <param name="promoterId">Promoter ID</param>
    /// <returns>List of events created by the promoter</returns>
    [HttpGet("promoter/{promoterId:int}")]
    [SwaggerOperation(
        Summary = "Gets events by promoter ID",
        Description = "Gets all events created by a specific promoter",
        OperationId = "GetEventsByPromoterId")]
    [SwaggerResponse(200, "The events were found", typeof(IEnumerable<EventResource>))]
    public async Task<ActionResult<IEnumerable<EventResource>>> GetEventsByPromoterId(int promoterId)
    {
        var getEventsByPromoterIdQuery = new GetEventsByPromoterIdQuery(promoterId);
        var events = await _eventQueryService.Handle(getEventsByPromoterIdQuery);
        var resources = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Create a new event
    /// </summary>
    /// <param name="resource">Event creation data</param>
    /// <returns>Created event</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new event",
        Description = "Creates a new musical event",
        OperationId = "CreateEvent")]
    [SwaggerResponse(201, "The event was created", typeof(EventResource))]
    [SwaggerResponse(400, "The event was not created")]
    public async Task<ActionResult<EventResource>> CreateEvent([FromBody] CreateEventResource resource)
    {
        var createEventCommand = CreateEventCommandFromResourceAssembler.ToCommandFromResource(resource);
        var eventEntity = await _eventCommandService.Handle(createEventCommand);
        
        if (eventEntity is null) 
            return BadRequest();
        
        var eventResource = EventResourceFromEntityAssembler.ToResourceFromEntity(eventEntity);
        return CreatedAtAction(nameof(GetEventById), new { id = eventEntity.Id }, eventResource);
    }

    /// <summary>
    /// Delete an event
    /// </summary>
    /// <param name="id">Event ID</param>
    /// <returns>Success status</returns>
    [HttpDelete("{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes an event",
        Description = "Deletes an event by its ID",
        OperationId = "DeleteEvent")]
    [SwaggerResponse(200, "The event was deleted")]
    [SwaggerResponse(404, "The event was not found")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        var result = await _eventCommandService.Handle(id);
        
        if (!result) 
            return NotFound();
        
        return Ok();
    }
} 
