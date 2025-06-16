using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;

/// <summary>
///     Contract repository implementation
/// </summary>
public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
    public ContractRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Contract?> FindByEventApplicationIdAsync(int eventApplicationId)
    {
        return await Context.Set<Contract>()
            .FirstOrDefaultAsync(c => c.EventApplicationId == eventApplicationId);
    }
} 