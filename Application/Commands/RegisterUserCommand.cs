using MediatR;

using tocaaqui_backend.Application.Dtos;

/// <summary>
/// Datos necesarios para registrar usuario (músico o promotor)
/// </summary>
public record RegisterUserCommand(
    string Name,
    string Email,
    string Password,
    string Role,
    string? Genre,
    string? Type,
    string? Description,
    string? ImageUrl
) : IRequest<AuthResultDto>;