namespace CODENINJAS.TocaAqui.API.IAM.Interfaces.Rest.Resources;

/// <summary>Payload de registro.</summary>
public record RegisterUserResource(
    string Name,
    string Email,
    string Password,
    string Role,
    string? ImageUrl = null);

