namespace tocaaqui_backend.Infrastructure.Auth;

using tocaaqui_backend.Domain.Users.Entities;

public class FakeJwtGenerator : IJwtGenerator
{
    public string Generate(User user)
        => $"{user.Id:N}.{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
}
