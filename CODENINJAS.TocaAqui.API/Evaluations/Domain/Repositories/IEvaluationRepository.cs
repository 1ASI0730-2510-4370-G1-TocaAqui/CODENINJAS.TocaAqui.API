using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;

public interface IEvaluationRepository
{
    Task<List<Evaluation>> GetAllAsync();
    Task<Evaluation?> GetByIdAsync(Guid id);
    Task<List<Evaluation>> GetByEntityAsync(Guid evaluatedEntityId, string entityType);
    Task AddAsync(Evaluation evaluation);
    Task DeleteAsync(Guid id);
}