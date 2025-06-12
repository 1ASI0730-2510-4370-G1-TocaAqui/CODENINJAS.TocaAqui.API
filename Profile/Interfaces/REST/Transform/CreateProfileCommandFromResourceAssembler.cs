using tocaaqui_backend.Profile.Domain.Model.Commands;
using tocaaqui_backend.Profile.Interfaces.REST.Resources;

namespace tocaaqui_backend.Profile.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommand(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.Name, resource.Email, resource.Bio, resource.Genre, resource.Type);
    }
}