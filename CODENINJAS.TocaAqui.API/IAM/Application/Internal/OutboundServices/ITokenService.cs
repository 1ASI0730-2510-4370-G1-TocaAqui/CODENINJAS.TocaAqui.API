using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;

namespace CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;

/// <summary>Contraparte de JWT (implementación en Infrastructure/Tokens).</summary>
public interface ITokenService
{
    string      GenerateToken(User user);
    Task<int?>  ValidateToken(string token);
}
