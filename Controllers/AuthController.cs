using MediatR;
using Microsoft.AspNetCore.Mvc;
using tocaaqui_backend.Application.Commands;
using tocaaqui_backend.Application.Queries;

namespace tocaaqui_backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;

    // POST api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand cmd)
    {
        var result = await _mediator.Send(cmd);
        return Ok(result);
    }

    // POST api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    // POST api/auth/logout   → el token se “olvida” en el cliente
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
}
