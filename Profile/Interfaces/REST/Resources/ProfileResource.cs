namespace tocaaqui_backend.Profile.Interfaces.REST.Resources;

public class ProfileResource
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Bio { get; set; }
    public string Genre { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string? ImageUrl { get; set; }
}