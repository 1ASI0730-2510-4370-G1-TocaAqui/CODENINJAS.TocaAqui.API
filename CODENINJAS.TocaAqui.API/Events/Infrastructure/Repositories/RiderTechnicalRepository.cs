using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;

/// <summary>
///     RiderTechnical repository implementation
/// </summary>
public class RiderTechnicalRepository : BaseRepository<RiderTechnical>, IRiderTechnicalRepository
{
    public RiderTechnicalRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<RiderTechnical?> FindByEventApplicationIdAsync(int eventApplicationId)
    {
        return await Context.Set<RiderTechnical>()
            .FirstOrDefaultAsync(r => r.EventApplicationId == eventApplicationId);
    }
} 