using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tocaaqui_backend.Events.Domain.Repositories;
using tocaaqui_backend.Events.Domain.Services;
using tocaaqui_backend.Events.Interfaces.REST.Resources;
using tocaaqui_backend.Events.Interfaces.REST.Transform;

namespace tocaaqui_backend.Events.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Event Applicants")]
public class EventApplicantsController : ControllerBase
{
    private readonly IEventApplicantCommandService _eventApplicantCommandService;
    private readonly IEventApplicantRepository _eventApplicantRepository;

    public EventApplicantsController(
        IEventApplicantCommandService eventApplicantCommandService,
        IEventApplicantRepository eventApplicantRepository)
    {
        _eventApplicantCommandService = eventApplicantCommandService;
        _eventApplicantRepository = eventApplicantRepository;
    }

    /// <summary>
    /// Apply to an event
    /// </summary>
    /// <param name="resource">Application data</param>
    /// <returns>Created application</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Apply to an event",
        Description = "Creates a new event application",
        OperationId = "ApplyToEvent")]
    [SwaggerResponse(201, "The application was created", typeof(EventApplicantResource))]
    [SwaggerResponse(400, "The application was not created")]
    public async Task<ActionResult<EventApplicantResource>> ApplyToEvent([FromBody] CreateEventApplicantResource resource)
    {
        try
        {
            var command = CreateEventApplicantCommandFromResourceAssembler.ToCommandFromResource(resource);
            var applicant = await _eventApplicantCommandService.Handle(command);
            
            if (applicant is null) 
                return BadRequest("Could not create application");
            
            var applicantResource = EventApplicantResourceFromEntityAssembler.ToResourceFromEntity(applicant);
            return CreatedAtAction(nameof(GetEventApplicantById), new { id = applicant.Id }, applicantResource);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error creating application: {ex.Message}");
        }
    }

    /// <summary>
    /// Get event applicant by ID
    /// </summary>
    /// <param name="id">Applicant ID</param>
    /// <returns>Applicant details</returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets an event applicant by ID",
        Description = "Gets an event applicant by its unique identifier",
        OperationId = "GetEventApplicantById")]
    [SwaggerResponse(200, "The applicant was found", typeof(EventApplicantResource))]
    [SwaggerResponse(404, "The applicant was not found")]
    public async Task<ActionResult<EventApplicantResource>> GetEventApplicantById(int id)
    {
        var applicant = await _eventApplicantRepository.FindByIdAsync(id);
        
        if (applicant is null) 
            return NotFound();
        
        var resource = EventApplicantResourceFromEntityAssembler.ToResourceFromEntity(applicant);
        return Ok(resource);
    }

    /// <summary>
    /// Get applicants by event ID
    /// </summary>
    /// <param name="eventId">Event ID</param>
    /// <returns>List of applicants for the event</returns>
    [HttpGet("event/{eventId:int}")]
    [SwaggerOperation(
        Summary = "Gets applicants by event ID",
        Description = "Gets all applicants for a specific event",
        OperationId = "GetApplicantsByEventId")]
    [SwaggerResponse(200, "The applicants were found", typeof(IEnumerable<EventApplicantResource>))]
    public async Task<ActionResult<IEnumerable<EventApplicantResource>>> GetApplicantsByEventId(int eventId)
    {
        var applicants = await _eventApplicantRepository.FindByEventIdAsync(eventId);
        var resources = applicants.Select(EventApplicantResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Get applications by user ID
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <returns>List of applications for the user</returns>
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets applications by user ID",
        Description = "Gets all applications submitted by a specific user",
        OperationId = "GetApplicationsByUserId")]
    [SwaggerResponse(200, "The applications were found", typeof(IEnumerable<EventApplicantResource>))]
    public async Task<ActionResult<IEnumerable<EventApplicantResource>>> GetApplicationsByUserId(int userId)
    {
        var applications = await _eventApplicantRepository.FindByUserIdAsync(userId);
        var resources = applications.Select(EventApplicantResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Update application status
    /// </summary>
    /// <param name="id">Applicant ID</param>
    /// <param name="resource">Status update data</param>
    /// <returns>Updated application</returns>
    [HttpPatch("{id:int}/status")]
    [SwaggerOperation(
        Summary = "Updates application status",
        Description = "Updates the status of an event application",
        OperationId = "UpdateApplicationStatus")]
    [SwaggerResponse(200, "The status was updated", typeof(EventApplicantResource))]
    [SwaggerResponse(404, "The application was not found")]
    public async Task<ActionResult<EventApplicantResource>> UpdateApplicationStatus(
        int id, 
        [FromBody] UpdateEventApplicantStatusResource resource)
    {
        var updatedApplicant = await _eventApplicantCommandService.UpdateApplicationStatus(id, resource.Status);
        
        if (updatedApplicant is null) 
            return NotFound();
        
        var applicantResource = EventApplicantResourceFromEntityAssembler.ToResourceFromEntity(updatedApplicant);
        return Ok(applicantResource);
    }

    /// <summary>
    /// Delete application
    /// </summary>
    /// <param name="id">Applicant ID</param>
    /// <returns>Success status</returns>
    [HttpDelete("{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes an application",
        Description = "Deletes an event application by its ID",
        OperationId = "DeleteApplication")]
    [SwaggerResponse(200, "The application was deleted")]
    [SwaggerResponse(404, "The application was not found")]
    public async Task<ActionResult> DeleteApplication(int id)
    {
        var result = await _eventApplicantCommandService.DeleteApplication(id);
        
        if (!result) 
            return NotFound();
        
        return Ok();
    }
} 
