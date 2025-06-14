namespace CODENINJAS.TocaAqui.API.IAM.Interfaces.Rest.Resources;

/// <summary>Payload de login.</summary>
public record LoginUserResource(
    string Email,
    string Password
);
