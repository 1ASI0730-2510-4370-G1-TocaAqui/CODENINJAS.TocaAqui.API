namespace CODENINJAS.TocaAqui.API.IAM.Interfaces.Rest.Resources;

/// <summary>Payload de registro.</summary>
public record RegisterUserResource(
    string Name,                   // opcional – por ahora lo ignoraremos en dominio
    string Email,
    string Password,
    string? Role = null,           // idem
    string? ImageUrl = null        // idem
);
