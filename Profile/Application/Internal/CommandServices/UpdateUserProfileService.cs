using tocaaqui_backend.Profile.Domain.Model.Commands;
using tocaaqui_backend.Profile.Domain.Repositories;
using tocaaqui_backend.Profile.Domain.Model.ValueObjects;

namespace tocaaqui_backend.Profile.Application.Internal.CommandServices;

public class UpdateUserProfileService
{
    private readonly IProfileRepository _profileRepository;

    public UpdateUserProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task ExecuteAsync(UpdateUserProfileCommand command)
    {
        var profile = await _profileRepository.FindByIdAsync(command.Id);
        if (profile == null) throw new Exception("Perfil no encontrado");

        profile.Update(
            command.Name,
            new Email(command.Email),
            command.Genre,
            command.Type,
            command.Description
        );

        await _profileRepository.UpdateAsync(profile);
        await _profileRepository.SaveChangesAsync();
    }
}