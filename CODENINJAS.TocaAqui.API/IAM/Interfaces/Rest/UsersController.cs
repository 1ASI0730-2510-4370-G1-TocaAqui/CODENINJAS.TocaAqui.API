using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.IAM.Domain.Services;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using CODENINJAS.TocaAqui.API.IAM.Interfaces.Rest.Resources;
using Microsoft.AspNetCore.Mvc;

namespace CODENINJAS.TocaAqui.API.IAM.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]              // => /api/v1/users
public class UsersController : ControllerBase
{
    private readonly IUserCommandService _commandService;
    private readonly IUserQueryService   _queryService;

    public UsersController(
        IUserCommandService commandService,
        IUserQueryService   queryService)
    {
        _commandService = commandService;
        _queryService   = queryService;
    }

    // ----------- SIGN-UP ----------------------------------------------------
    [HttpPost("[action]")]                  // =>  POST /api/v1/users/sign-up
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] RegisterUserResource body)
    {
        var command = new SignUpCommand(
            body.Name,
            body.Email,
            body.Password,
            body.Role,
            body.Genre,      // ← usar el valor del body
            body.Type,       // ← usar el valor del body
            body.Description,// ← usar el valor del body
            body.ImageUrl);
        await _commandService.Handle(command);
        return Ok(new { message = "User created successfully" });
    }

    // ----------- SIGN-IN ----------------------------------------------------
    [HttpPost("[action]")]                  // =>  POST /api/v1/users/sign-in
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] LoginUserResource body)
    {
        var command           = new SignInCommand(body.Email, body.Password);
        var (user, token)     = await _commandService.Handle(command);
        var userResource      = new UserResource(user.Id, user.Email, user.Name, user.Role, user.Genre, user.Type, user.Description, user.ImageUrl);
        return Ok(new { user = userResource, token });
    }

    // ----------- GET ALL (requiere token) ----------------------------------
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<UserResource>> GetAll()
    {
        var users = await _queryService.Handle(new GetAllUsersQuery());
        return users.Select(u => new UserResource(u.Id, u.Email, u.Name, u.Role, u.Genre, u.Type, u.Description, u.ImageUrl));

    }

    // ----------- GET BY ID (requiere token) --------------------------------
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _queryService.Handle(new GetUserByIdQuery(id));
        return user is null
            ? NotFound()
            : Ok(new UserResource(user.Id, user.Email, user.Name, user.Role, user.Genre, user.Type, user.Description, user.ImageUrl));
    }
}
