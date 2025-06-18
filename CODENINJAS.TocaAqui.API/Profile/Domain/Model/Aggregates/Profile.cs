using CODENINJAS.TocaAqui.API.Profile.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string Genre { get; private set; }
    public string Type { get; private set; }
    public string Description { get; private set; }
    public string? ProfileImagePath { get; private set; }
    
    public Profile(int id, string name, Email email, string genre, string type, string description, string? profileImagePath = null)
    {
        Id = id;
        Name = name;
        Email = email;
        Genre = genre;
        Type = type;
        Description = description;
        ProfileImagePath = profileImagePath;
    }
    
    public void Update(string name, Email email, string genre, string type, string description, string? profileImagePath = null)
    {
        Name = name;
        Email = email;
        Genre = genre;
        Type = type;
        Description = description;
        if (profileImagePath != null)
            ProfileImagePath = profileImagePath;
    }
}
