using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.CommandServices;

public class EvaluationCommandService :IEvaluationCommandService
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EvaluationCommandService(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork)
    {
        _evaluationRepository = evaluationRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Evaluation?> Handle(CreateEvaluationCommand command)
    {
        var evaluation = new Evaluation(command);
        try
        {
            await _evaluationRepository.AddAsync(evaluation);
            await _unitOfWork.CompleteAsync();
            return evaluation;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating invitation: {ex.Message}");
            return null;
        }
        
    }
}