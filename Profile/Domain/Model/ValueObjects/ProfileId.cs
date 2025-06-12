namespace tocaaqui_backend.Profile.Domain.Model.ValueObjects;

public class ProfileId
{
    public Guid Value { get; }

    public ProfileId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("ID de perfil inválido");

        Value = value;
    }

    public override string ToString() => Value.ToString();

    public override bool Equals(object? obj)
    {
        return obj is ProfileId id && id.Value == Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
