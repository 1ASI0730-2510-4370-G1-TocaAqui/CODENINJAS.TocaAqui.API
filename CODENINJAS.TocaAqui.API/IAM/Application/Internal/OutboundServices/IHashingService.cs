namespace CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;

/// <summary>Contraparte de hashing (BCrypt en infraestructura).</summary>
public interface IHashingService
{
    string HashPassword(string password);
    bool   VerifyPassword(string password, string passwordHash);
}
