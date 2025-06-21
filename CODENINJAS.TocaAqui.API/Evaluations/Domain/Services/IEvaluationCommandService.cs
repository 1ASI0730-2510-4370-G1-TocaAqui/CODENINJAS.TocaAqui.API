using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Services;

public interface IEvaluationCommandService
{
    Task<Evaluation?> Handle(CreateEvaluationCommand command);
}