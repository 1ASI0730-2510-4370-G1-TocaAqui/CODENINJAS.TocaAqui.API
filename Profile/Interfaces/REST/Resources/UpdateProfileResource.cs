namespace tocaaqui_backend.Profile.Interfaces.REST.Resources;

public class UpdateProfileResource
{
    public string Name { get; set; } = default!;
    public string? Bio { get; set; }
    public string Genre { get; set; } = default!;
    public string Type { get; set; } = default!;
}
