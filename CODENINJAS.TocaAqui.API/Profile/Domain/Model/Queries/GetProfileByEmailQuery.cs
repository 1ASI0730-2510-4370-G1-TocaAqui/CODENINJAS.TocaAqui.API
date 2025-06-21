namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Queries;

public class GetProfileByEmailQuery
{
    public string Email { get; set; }

    public GetProfileByEmailQuery(string email)
    {
        Email = email;
    }
}
