using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.CommandServices;

public class EvaluationCommandService
{
    private readonly IEvaluationRepository _repository;

    public EvaluationCommandService(IEvaluationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Evaluation> Handle(CreateEvaluationCommand command)
    {
        var evaluation = new Evaluation(
            command.UserId,
            command.EntityType,
            command.EntityId,
            command.Score,
            command.Comment
        );

        await _repository.AddAsync(evaluation);
        return evaluation;
    }
}