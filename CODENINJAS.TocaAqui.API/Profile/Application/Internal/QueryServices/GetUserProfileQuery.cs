namespace CODENINJAS.TocaAqui.API.Profile.Application.Internal.QueryServices;

public class GetUserProfileQuery
{
    public int Id { get; set; }

    public GetUserProfileQuery(int id)
    {
        Id = id;
    }
}
