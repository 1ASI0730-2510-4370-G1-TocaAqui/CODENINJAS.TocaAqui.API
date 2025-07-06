using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Services;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Transform;
using CODENINJAS.TocaAqui.API.IAM.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Invitations")]
public class InvitationsController : ControllerBase
{
    private readonly IInvitationCommandService _invitationCommandService;
    private readonly IInvitationRepository _invitationRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;

    public InvitationsController(
        IInvitationCommandService invitationCommandService,
        IInvitationRepository invitationRepository,
        IEventRepository eventRepository,
        IUserRepository userRepository)
    {
        _invitationCommandService = invitationCommandService;
        _invitationRepository = invitationRepository;
        _eventRepository = eventRepository;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Create invitation
    /// </summary>
    /// <param name="resource">Invitation data</param>
    /// <returns>Created invitation</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create an invitation",
        Description = "Creates a new invitation to an event",
        OperationId = "CreateInvitation")]
    [SwaggerResponse(201, "The invitation was created", typeof(InvitationResource))]
    [SwaggerResponse(400, "The invitation was not created")]
    public async Task<ActionResult<InvitationResource>> CreateInvitation([FromBody] CreateInvitationResource resource)
    {
        try
        {
            Console.WriteLine("=== NUEVO CONTROLADOR DE INVITACIONES ===");
            Console.WriteLine($"EventId: {resource.EventId}");
            Console.WriteLine($"ArtistId: {resource.ArtistId}");
            Console.WriteLine($"PromoterId: {resource.PromoterId}");
            
            // Obtener datos reales del evento
            var eventEntity = await _eventRepository.FindByIdAsync(resource.EventId);
            if (eventEntity == null)
                return BadRequest($"Event with ID {resource.EventId} not found");
                
            Console.WriteLine($"Event encontrado: {eventEntity.Name}");

            // Obtener datos reales del promotor
            var promoter = await _userRepository.FindByIdAsync(resource.PromoterId);
            if (promoter == null)
                return BadRequest($"Promoter with ID {resource.PromoterId} not found");
                
            Console.WriteLine($"Promoter encontrado: {promoter.Name}");

            // Obtener datos reales del artista
            var artist = await _userRepository.FindByIdAsync(resource.ArtistId);
            if (artist == null)
                return BadRequest($"Artist with ID {resource.ArtistId} not found");
                
            Console.WriteLine($"Artist encontrado: {artist.Name}");

            // Crear el comando con datos reales
            var command = new CreateInvitationCommand(
                resource.EventId,
                eventEntity.Name,
                eventEntity.Date,
                eventEntity.Location,
                eventEntity.ImageUrl ?? "",
                resource.PromoterId,
                promoter.Name,
                resource.ArtistId,
                artist.Name,
                resource.Message,
                "Pending"
            );
            
            Console.WriteLine($"Comando creado con EventName: {command.EventName}");
            Console.WriteLine($"Comando creado con PromoterName: {command.PromoterName}");
            Console.WriteLine($"Comando creado con ArtistName: {command.ArtistName}");

            var invitation = await _invitationCommandService.Handle(command);
            
            if (invitation is null) 
                return BadRequest("Could not create invitation");
                
            Console.WriteLine($"Invitación creada con ID: {invitation.Id}");
            
            var invitationResource = InvitationResourceFromEntityAssembler.ToResourceFromEntity(invitation);
            return CreatedAtAction(nameof(GetInvitationById), new { id = invitation.Id }, invitationResource);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en CreateInvitation: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
            return BadRequest($"Error creating invitation: {ex.Message}");
        }
    }

    /// <summary>
    /// Get invitation by ID
    /// </summary>
    /// <param name="id">Invitation ID</param>
    /// <returns>Invitation details</returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets an invitation by ID",
        Description = "Gets an invitation by its unique identifier",
        OperationId = "GetInvitationById")]
    [SwaggerResponse(200, "The invitation was found", typeof(InvitationResource))]
    [SwaggerResponse(404, "The invitation was not found")]
    public async Task<ActionResult<InvitationResource>> GetInvitationById(int id)
    {
        var invitation = await _invitationRepository.FindByIdAsync(id);
        
        if (invitation is null) 
            return NotFound();
        
        var resource = InvitationResourceFromEntityAssembler.ToResourceFromEntity(invitation);
        return Ok(resource);
    }

    /// <summary>
    /// Get invitations by event ID
    /// </summary>
    /// <param name="eventId">Event ID</param>
    /// <returns>List of invitations for the event</returns>
    [HttpGet("event/{eventId:int}")]
    [SwaggerOperation(
        Summary = "Gets invitations by event ID",
        Description = "Gets all invitations for a specific event",
        OperationId = "GetInvitationsByEventId")]
    [SwaggerResponse(200, "The invitations were found", typeof(IEnumerable<InvitationResource>))]
    public async Task<ActionResult<IEnumerable<InvitationResource>>> GetInvitationsByEventId(int eventId)
    {
        var invitations = await _invitationRepository.FindByEventIdAsync(eventId);
        var resources = invitations.Select(InvitationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Get invitations by artist ID
    /// </summary>
    /// <param name="artistId">Artist ID</param>
    /// <returns>List of invitations for the artist</returns>
    [HttpGet("artist/{artistId:int}")]
    [SwaggerOperation(
        Summary = "Gets invitations by artist ID",
        Description = "Gets all invitations sent to a specific artist",
        OperationId = "GetInvitationsByArtistId")]
    [SwaggerResponse(200, "The invitations were found", typeof(IEnumerable<InvitationResource>))]
    public async Task<ActionResult<IEnumerable<InvitationResource>>> GetInvitationsByArtistId(int artistId)
    {
        var invitations = await _invitationRepository.FindByArtistIdAsync(artistId);
        var resources = invitations.Select(InvitationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Get invitations by promoter ID
    /// </summary>
    /// <param name="promoterId">Promoter ID</param>
    /// <returns>List of invitations sent by the promoter</returns>
    [HttpGet("promoter/{promoterId:int}")]
    [SwaggerOperation(
        Summary = "Gets invitations by promoter ID",
        Description = "Gets all invitations sent by a specific promoter",
        OperationId = "GetInvitationsByPromoterId")]
    [SwaggerResponse(200, "The invitations were found", typeof(IEnumerable<InvitationResource>))]
    public async Task<ActionResult<IEnumerable<InvitationResource>>> GetInvitationsByPromoterId(int promoterId)
    {
        var invitations = await _invitationRepository.FindByPromoterIdAsync(promoterId);
        var resources = invitations.Select(InvitationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Respond to invitation
    /// </summary>
    /// <param name="id">Invitation ID</param>
    /// <param name="resource">Response data</param>
    /// <returns>Updated invitation</returns>
    [HttpPatch("{id:int}/respond")]
    [SwaggerOperation(
        Summary = "Respond to invitation",
        Description = "Responds to an invitation (accept/reject)",
        OperationId = "RespondToInvitation")]
    [SwaggerResponse(200, "The invitation was updated", typeof(InvitationResource))]
    [SwaggerResponse(404, "The invitation was not found")]
    public async Task<ActionResult<InvitationResource>> RespondToInvitation(
        int id, 
        [FromBody] UpdateEventApplicantStatusResource resource)
    {
        var updatedInvitation = await _invitationCommandService.RespondToInvitation(id, resource.Status);
        
        if (updatedInvitation is null) 
            return NotFound();
        
        var invitationResource = InvitationResourceFromEntityAssembler.ToResourceFromEntity(updatedInvitation);
        return Ok(invitationResource);
    }

    /// <summary>
    /// Delete invitation
    /// </summary>
    /// <param name="id">Invitation ID</param>
    /// <returns>Success status</returns>
    [HttpDelete("{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes an invitation",
        Description = "Deletes an invitation by its ID",
        OperationId = "DeleteInvitation")]
    [SwaggerResponse(200, "The invitation was deleted")]
    [SwaggerResponse(404, "The invitation was not found")]
    public async Task<ActionResult> DeleteInvitation(int id)
    {
        var result = await _invitationCommandService.DeleteInvitation(id);
        
        if (!result) 
            return NotFound();
        
        return Ok();
    }
} 
