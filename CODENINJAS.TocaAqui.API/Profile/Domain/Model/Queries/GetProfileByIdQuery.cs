namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Queries;

public class GetProfileByIdQuery
{
    public Guid Id { get; set; }

    public GetProfileByIdQuery(Guid id)
    {
        Id = id;
    }
}
