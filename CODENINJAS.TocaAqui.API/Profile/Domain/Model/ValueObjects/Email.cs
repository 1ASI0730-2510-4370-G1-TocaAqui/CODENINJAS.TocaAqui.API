namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.ValueObjects;

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            throw new ArgumentException("Email inválido");

        Value = value;
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        return obj is Email email && email.Value == Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
