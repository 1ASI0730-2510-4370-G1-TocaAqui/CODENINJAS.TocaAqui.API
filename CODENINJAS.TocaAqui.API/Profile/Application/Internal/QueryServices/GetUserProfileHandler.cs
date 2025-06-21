using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Profile.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Profile.Application.Internal.QueryServices;

public class GetUserProfileHandler
{
    private readonly IProfileRepository _profileRepository;

    public GetUserProfileHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<ProfileDto> HandleAsync(GetUserProfileQuery query)
    {
        var profile = await _profileRepository.FindByIdAsync(query.Id);
        if (profile == null) throw new Exception("Perfil no encontrado");

        return new ProfileDto
        {
            Id = profile.Id,
            Name = profile.Name,
            Email = profile.Email.Value,
            Bio = profile.Description,
            Genre = profile.Genre,
            Type = profile.Type,
            ImageUrl = profile.ProfileImagePath
        };
    }
}