using MediatR;
using tocaaqui_backend.Application.Dtos;

namespace tocaaqui_backend.Application.Queries;

/// <summary>
/// Query de login: se envía a MediatR con email y password.
/// </summary>
public record LoginQuery(
    string Email,
    string Password
) : IRequest<AuthResultDto>;
