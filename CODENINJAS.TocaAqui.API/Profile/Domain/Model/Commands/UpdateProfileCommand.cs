using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates;
using MediatR;

namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Commands;

public class UpdateProfileCommand : IRequest<ProfileDto>
{
    public int Id { get; }
    public string Name { get; }
    public string Bio { get; }
    public string Genre { get; }
    public string Type { get; }

    public UpdateProfileCommand(int id, string name, string bio, string genre, string type)
    {
        Id = id;
        Name = name;
        Bio = bio;
        Genre = genre;
        Type = type;
    }
}