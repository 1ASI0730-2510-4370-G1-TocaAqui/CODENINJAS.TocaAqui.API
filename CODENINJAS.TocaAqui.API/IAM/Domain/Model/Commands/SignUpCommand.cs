namespace CODENINJAS.TocaAqui.API.IAM.Domain.Model.Commands;

/// <summary>Comando para registrar un nuevo usuario.</summary>
public record SignUpCommand(
    string Name,
    string Email,
    string Password,
    string Role,
    string? Genre       = null,
    string? Type        = null,
    string? Description = null,
    string? ImageUrl    = null);
