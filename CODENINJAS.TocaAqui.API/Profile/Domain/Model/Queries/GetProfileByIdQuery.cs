namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Queries;

public class GetProfileByIdQuery
{
    public int Id { get; set; }

    public GetProfileByIdQuery(int id)
    {
        Id = id;
    }
}
