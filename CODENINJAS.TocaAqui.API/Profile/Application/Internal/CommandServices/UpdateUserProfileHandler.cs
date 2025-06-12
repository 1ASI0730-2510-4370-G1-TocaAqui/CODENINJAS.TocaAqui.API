using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Profile.Application.Internal.CommandServices;

public class UpdateUserProfileHandler
{
    private readonly UpdateUserProfileService _service;

    public UpdateUserProfileHandler(UpdateUserProfileService service)
    {
        _service = service;
    }

    public async Task HandleAsync(UpdateUserProfileCommand command)
    {
        await _service.ExecuteAsync(command);
    }
}