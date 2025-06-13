namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;

public class GetEvaluationsByEntityQuery
{
    public string EntityType { get; }
    public Guid EntityId { get; }

    public GetEvaluationsByEntityQuery(string entityType, Guid entityId)
    {
        EntityType = entityType;
        EntityId = entityId;
    }
}