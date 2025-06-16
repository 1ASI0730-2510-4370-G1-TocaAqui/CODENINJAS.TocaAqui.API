namespace CODENINJAS.TocaAqui.API.IAM.Interfaces.Rest.Resources;

/// <summary>Lo que exponemos al frontend.</summary>
public record UserResource(
    int Id,
    string Email,
    string? Name = null,
    string? Role = null,
    string? Genre = null,
    string? Type = null,
    string? Description = null,
    string? ImageUrl = null
);
