using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Profile.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Profile.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommand(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.Name, resource.Email, resource.Bio, resource.Genre, resource.Type);
    }
}