using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Repositories;

public class EfEvaluationRepository : IEvaluationRepository
{
    private readonly EvaluationDbContext _context;

    public EfEvaluationRepository(EvaluationDbContext context)
    {
        _context = context;
    }

    public Task<List<Evaluation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Evaluation?> GetByIdAsync(Guid id)
    {
        return await _context.Evaluations.FindAsync(id);
    }

    public Task<List<Evaluation>> GetByEntityAsync(Guid evaluatedEntityId, string entityType)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Evaluation>> GetByEntityAsync(string entityType, Guid entityId)
    {
        return await _context.Evaluations
            .Where(e => e.EntityType == entityType && e.EntityId == entityId)
            .ToListAsync();
    }

    public async Task AddAsync(Evaluation evaluation)
    {
        await _context.Evaluations.AddAsync(evaluation);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}