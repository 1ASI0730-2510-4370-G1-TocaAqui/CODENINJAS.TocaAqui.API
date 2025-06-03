namespace tocaaqui_backend.Domain.Users.ValueObjects;

public sealed record PasswordHash
{
    public string Value { get; }

    private PasswordHash(string value) => Value = value;

    public static PasswordHash FromHash(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("Hash de contraseña vacío", nameof(hash));

        return new PasswordHash(hash);
    }

    public override string ToString() => Value;
}
