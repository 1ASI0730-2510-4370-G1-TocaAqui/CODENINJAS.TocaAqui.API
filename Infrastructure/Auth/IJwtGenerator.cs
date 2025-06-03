namespace tocaaqui_backend.Infrastructure.Auth;

using tocaaqui_backend.Domain.Users.Entities;

public interface IJwtGenerator
{
    string Generate(User user);
}
