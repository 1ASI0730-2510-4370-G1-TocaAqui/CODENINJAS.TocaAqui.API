using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.Evaluations.Infraestructure.Repositories;

public class EvaluationRepository: BaseRepository<Evaluation>,IEvaluationRepository
{
    public EvaluationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Evaluation>> FindByTypeAsync(string type)
    {
        return await Context.Set<Evaluation>()
            .Where(e => e.Type == type)
            .ToListAsync();
    }
}