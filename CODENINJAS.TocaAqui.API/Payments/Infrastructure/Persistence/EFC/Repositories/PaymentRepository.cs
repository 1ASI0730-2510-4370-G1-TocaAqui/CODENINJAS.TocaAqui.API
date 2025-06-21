using Microsoft.EntityFrameworkCore;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Payments.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CODENINJAS.TocaAqui.API.Payments.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Payment repository implementation using Entity Framework Core
/// </summary>
public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Payment>> FindByMusicianIdAsync(int musicianId)
    {
        return await Context.Set<Payment>()
            .Include(p => p.StatusHistory)
            .Where(p => p.MusicianId == musicianId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> FindByPromoterIdAsync(int promoterId)
    {
        return await Context.Set<Payment>()
            .Include(p => p.StatusHistory)
            .Where(p => p.PromoterId == promoterId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> FindByEventIdAsync(int eventId)
    {
        return await Context.Set<Payment>()
            .Include(p => p.StatusHistory)
            .Where(p => p.EventId == eventId)
            .ToListAsync();
    }

    public override async Task<Payment?> FindByIdAsync(int id)
    {
        return await Context.Set<Payment>()
            .Include(p => p.StatusHistory)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Payment>> ListAsync()
    {
        return await Context.Set<Payment>()
            .Include(p => p.StatusHistory)
            .ToListAsync();
    }
} 