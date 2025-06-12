namespace tocaaqui_backend.Profile.Domain.Model.Queries;

public class GetProfileByEmailQuery
{
    public string Email { get; set; }

    public GetProfileByEmailQuery(string email)
    {
        Email = email;
    }
}
