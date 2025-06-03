using MediatR;
using BCrypt.Net;
using tocaaqui_backend.Application.Dtos;
using tocaaqui_backend.Domain.Users.Interfaces;
using tocaaqui_backend.Infrastructure.Auth;

namespace tocaaqui_backend.Application.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResultDto>
{
    private readonly IUserRepository _repo;
    private readonly IJwtGenerator _jwt;

    public LoginQueryHandler(IUserRepository repo, IJwtGenerator jwt)
    {
        _repo = repo;
        _jwt = jwt;
    }

    public async Task<AuthResultDto> Handle(LoginQuery q, CancellationToken ct)
    {
        var user = await _repo.GetByEmailAsync(q.Email, ct)
                   ?? throw new InvalidOperationException("Credenciales incorrectas.");

        // Validar contraseña (hash comparado)
        if (!BCrypt.Net.BCrypt.Verify(q.Password, user.Password.Value))
            throw new InvalidOperationException("Credenciales incorrectas.");

        var token = _jwt.Generate(user);

        return new AuthResultDto(
            user.Id,
            user.Name,
            user.Email.Value,
            user.Role.ToString().ToLower(),
            token);
    }
}
