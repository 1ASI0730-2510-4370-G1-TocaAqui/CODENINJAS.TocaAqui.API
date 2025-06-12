namespace CODENINJAS.TocaAqui.API.Profile.Domain.Services;

public class ProfileDomainService
{
    public bool IsProfileEligibleForEvent(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile)
    {
        return profile.Description.Length > 100;
    }
}
