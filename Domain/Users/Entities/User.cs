using tocaaqui_backend.Domain.Users.Enums;
using tocaaqui_backend.Domain.Users.ValueObjects;

namespace tocaaqui_backend.Domain.Users.Entities;

/// <summary>
/// Aggregate root User
/// </summary>
public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public PasswordHash Password { get; private set; } = default!;
    public Role Role { get; private set; }
    public ImageUrl? Image { get; private set; }

    // Solo músico
    public MusicGenre? Genre { get; private set; }
    public ArtistType? Type { get; private set; }
    public string? Description { get; private set; }

    private User() { } // Para EF / deserialización

    private User(
        string name,
        Email email,
        PasswordHash password,
        Role role,
        ImageUrl? image,
        MusicGenre? genre,
        ArtistType? type,
        string? description)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        Image = image;
        Genre = genre;
        Type = type;
        Description = description;
    }

    /* ---------- Factories ---------- */

    public static User CreateMusico(
        string name,
        Email email,
        PasswordHash passwordHash,
        string? imageUrlStr,
        MusicGenre genre,
        ArtistType type,
        string description) =>
        new(
            name,
            email,
            passwordHash,
            Role.Musico,
            ImageUrl.Create(imageUrlStr),
            genre,
            type,
            description);

    public static User CreatePromotor(
        string name,
        Email email,
        PasswordHash passwordHash,
        string? imageUrlStr) =>
        new(
            name,
            email,
            passwordHash,
            Role.Promotor,
            ImageUrl.Create(imageUrlStr),
            null,
            null,
            null);
}
