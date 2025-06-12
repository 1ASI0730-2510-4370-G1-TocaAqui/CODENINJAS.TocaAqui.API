using MediatR;
using tocaaqui_backend.Profile.Domain.Model.Aggregates;

namespace tocaaqui_backend.Profile.Domain.Model.Commands;

public class CreateProfileCommand : IRequest<ProfileDto>
{
    public string Name { get; }
    public string Email { get; }
    public string Bio { get; }
    public string Genre { get; }
    public string Type { get; }

    public CreateProfileCommand(string name, string email, string bio, string genre, string type)
    {
        Name = name;
        Email = email;
        Bio = bio;
        Genre = genre;
        Type = type;
    }
}
