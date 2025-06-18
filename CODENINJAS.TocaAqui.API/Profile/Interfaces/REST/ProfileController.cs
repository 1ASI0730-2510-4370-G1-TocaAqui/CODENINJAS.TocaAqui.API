using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Profile.Interfaces.REST.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CODENINJAS.TocaAqui.API.Profile.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var profiles = await _mediator.Send(new GetAllProfilesQuery());
        return Ok(profiles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var profile = await _mediator.Send(new GetProfileByIdQuery(id));
        return profile is not null ? Ok(profile) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProfileResource resource)
    {
        var command = new CreateProfileCommand(resource.Name, resource.Email, resource.Bio, resource.Genre, resource.Type);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProfileResource resource)
    {
        var command = new UpdateProfileCommand(id, resource.Name, resource.Bio, resource.Genre, resource.Type);
        var result = await _mediator.Send(command);
        return result != null ? NoContent() : NotFound();
    }

    [HttpPost("{id}/upload-image")]
    public async Task<IActionResult> UploadImage(int id, [FromForm] UploadImageResource file)
    {
        if (file.Image is null || file.Image.Length == 0) return BadRequest("Invalid image");

        using var ms = new MemoryStream();
        await file.Image.CopyToAsync(ms);
        var bytes = ms.ToArray();

        var command = new UploadProfileImageCommand(id, bytes, file.Image.FileName, file.Image.ContentType);
        var result = await _mediator.Send(command);

        return Ok(new { imageUrl = result });
    }
}