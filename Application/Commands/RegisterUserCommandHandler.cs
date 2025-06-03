using MediatR;
using tocaaqui_backend.Application.Dtos;
using tocaaqui_backend.Domain.Users.Entities;
using tocaaqui_backend.Domain.Users.Enums;
using tocaaqui_backend.Domain.Users.Interfaces;
using tocaaqui_backend.Domain.Users.ValueObjects;
using tocaaqui_backend.Infrastructure.Auth;

namespace tocaaqui_backend.Application.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResultDto>
{
    private readonly IUserRepository _repo;
    private readonly IJwtGenerator _jwt;

    public RegisterUserCommandHandler(IUserRepository repo, IJwtGenerator jwt)
    {
        _repo = repo;
        _jwt = jwt;
    }

    public async Task<AuthResultDto> Handle(RegisterUserCommand cmd, CancellationToken ct)
    {
        if (await _repo.ExistsEmailAsync(cmd.Email, ct))
            throw new InvalidOperationException("El email ya está registrado.");

        var email = Email.Create(cmd.Email);
        var password = PasswordHash.FromHash(BCrypt.Net.BCrypt.HashPassword(cmd.Password));

        User user = cmd.Role.ToLower() switch
        {
            "musico" => User.CreateMusico(
                            cmd.Name,
                            email,
                            password,
                            cmd.ImageUrl,
                            Enum.Parse<MusicGenre>(cmd.Genre ?? "Otro", ignoreCase: true),
                            Enum.Parse<ArtistType>(cmd.Type ?? "Solista", ignoreCase: true),
                            cmd.Description ?? string.Empty),

            "promotor" => User.CreatePromotor(
                            cmd.Name,
                            email,
                            password,
                            cmd.ImageUrl),

            _ => throw new ArgumentException("Rol inválido")
        };

        await _repo.AddAsync(user, ct);

        var token = _jwt.Generate(user);

        return new AuthResultDto(
            user.Id,
            user.Name,
            user.Email.Value,
            user.Role.ToString().ToLower(),
            token);
    }
}
