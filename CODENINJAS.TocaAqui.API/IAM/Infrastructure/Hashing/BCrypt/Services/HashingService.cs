using CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Hashing.BCrypt.Services;

/// <inheritdoc />
public class HashingService : IHashingService
{
    public string HashPassword(string password)         => BCryptNet.HashPassword(password);

    public bool   VerifyPassword(string password, string hash) => BCryptNet.Verify(password, hash);
}
