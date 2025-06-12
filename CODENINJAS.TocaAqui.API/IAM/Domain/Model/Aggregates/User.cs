using System.Text.Json.Serialization;

namespace CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;

/// <summary>
///     Entidad raíz que representa a un usuario.
///     Algunos atributos son opcionales y solo aplican a músicos.
/// </summary>
public class User
{
    // ctor requerido por EF Core
    public User() { }

    public User(
        string name,
        string email,
        string passwordHash,
        string role,
        string? genre        = null,
        string? type         = null,
        string? description  = null,
        string? imageUrl     = null)
    {
        Name         = name;
        Email        = email;
        PasswordHash = passwordHash;
        Role         = role;
        Genre        = genre;
        Type         = type;
        Description  = description;
        ImageUrl     = imageUrl;
    }

    public int    Id           { get; private set; }
    public string Name         { get; private set; } = null!;
    public string Email        { get; private set; } = null!;

    [JsonIgnore]
    public string PasswordHash { get; private set; } = null!;

    public string Role         { get; private set; } = null!;
    public string? Genre       { get; private set; }
    public string? Type        { get; private set; }
    public string? Description { get; private set; }
    public string? ImageUrl    { get; private set; }

    // ---------- operaciones básicas ----------
    public void UpdatePasswordHash(string newHash) => PasswordHash = newHash;
}
