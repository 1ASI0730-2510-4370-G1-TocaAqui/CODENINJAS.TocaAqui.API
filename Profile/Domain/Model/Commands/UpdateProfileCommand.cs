using MediatR;
using tocaaqui_backend.Profile.Domain.Model.Aggregates;

namespace tocaaqui_backend.Profile.Domain.Model.Commands;

public class UpdateProfileCommand : IRequest<ProfileDto>
{
    public Guid Id { get; }
    public string Name { get; }
    public string Bio { get; }
    public string Genre { get; }
    public string Type { get; }

    public UpdateProfileCommand(Guid id, string name, string bio, string genre, string type)
    {
        Id = id;
        Name = name;
        Bio = bio;
        Genre = genre;
        Type = type;
    }
}