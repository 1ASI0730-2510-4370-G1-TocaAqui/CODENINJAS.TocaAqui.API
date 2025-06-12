using tocaaqui_backend.Profile.Domain.Model.Aggregates;

namespace tocaaqui_backend.Profile.Domain.Services;

public class ProfileDomainService
{
    public bool IsProfileEligibleForEvent(Model.Aggregates.Profile profile)
    {
        return profile.Description.Length > 100;
    }
}
