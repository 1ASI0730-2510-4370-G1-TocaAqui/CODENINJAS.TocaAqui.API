using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Services;

public interface IEvaluationQueryService
{
    Task<IEnumerable<Evaluation>> Handle(GetAllEvaluationsByTypeQuery query);
}