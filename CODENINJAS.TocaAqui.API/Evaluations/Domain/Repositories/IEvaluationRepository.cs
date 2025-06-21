using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;

public interface IEvaluationRepository :IBaseRepository<Evaluation>
{
    Task<IEnumerable<Evaluation>>FindByTypeAsync(string type);
}