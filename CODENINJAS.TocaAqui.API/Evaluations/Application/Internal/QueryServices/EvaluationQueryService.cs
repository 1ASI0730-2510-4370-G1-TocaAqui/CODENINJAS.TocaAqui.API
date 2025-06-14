using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.QueryServices;

public class EvaluationQueryService : IEvaluationQueryService
{
    
    
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EvaluationQueryService(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork)
    {
        _evaluationRepository = evaluationRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Evaluation>> Handle(GetAllEvaluationsByTypeQuery query)
    {
        return await _evaluationRepository.FindByTypeAsync(query.Type);
    }
}