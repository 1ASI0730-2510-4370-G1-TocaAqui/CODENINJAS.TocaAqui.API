namespace CODENINJAS.TocaAqui.API.IAM.Domain.Model.Commands;

/// <summary>Comando para iniciar sesión.</summary>
public record SignInCommand(string Email, string Password);
