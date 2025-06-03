using System.Text.RegularExpressions;

namespace tocaaqui_backend.Domain.Users.ValueObjects;

public sealed record Email
{
    private static readonly Regex _regex =
        new(@"^[\w\.\-]+@([\w\-]+\.)+[a-zA-Z]{2,4}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !_regex.IsMatch(value))
            throw new ArgumentException("Email inválido", nameof(value));

        return new Email(value.Trim().ToLower());
    }

    public override string ToString() => Value;
}
