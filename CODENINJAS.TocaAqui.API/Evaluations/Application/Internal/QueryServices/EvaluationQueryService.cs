using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.QueryServices;

public class EvaluationQueryService
{
    private readonly IEvaluationRepository _repository;

    public EvaluationQueryService(IEvaluationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Evaluation?> Handle(GetEvaluationByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.EvaluationId);
    }

    public async Task<IEnumerable<Evaluation>> Handle(GetEvaluationsByEntityQuery query)
    {
        return await _repository.GetByEntityAsync(query.EntityType, query.EntityId);
    }
}