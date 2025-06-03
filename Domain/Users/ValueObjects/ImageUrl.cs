namespace tocaaqui_backend.Domain.Users.ValueObjects;

public sealed record ImageUrl
{
    public string Value { get; }

    private ImageUrl(string value) => Value = value;

    /// <summary>
    /// Crea una instancia solo si la URL no está vacía.
    /// Devuelve null cuando la cadena está vacía o es whitespace.
    /// </summary>
    public static ImageUrl? Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return new ImageUrl(value.Trim());
    }

    public override string ToString() => Value;
}
