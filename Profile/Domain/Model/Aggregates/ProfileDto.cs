namespace tocaaqui_backend.Profile.Domain.Model.Aggregates;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string Genre { get; set; }
    public string Type { get; set; }
    public string ImageUrl { get; set; }
}