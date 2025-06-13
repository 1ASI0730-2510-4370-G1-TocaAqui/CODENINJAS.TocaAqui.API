namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;

public class GetEvaluationByIdQuery
{
    public Guid Id { get; }

    public GetEvaluationByIdQuery(Guid id)
    {
        Id = id;
    }
}