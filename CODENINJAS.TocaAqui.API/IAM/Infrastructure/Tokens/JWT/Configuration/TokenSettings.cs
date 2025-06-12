namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Tokens.JWT.Configuration;

/// <summary>Valores leídos del appsettings.json (sección "TokenSettings").</summary>
public class TokenSettings
{
    public string Secret { get; set; } = null!;
}
