using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Payments.Domain.Repositories;

/// <summary>
///     Payment repository interface
/// </summary>
public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<IEnumerable<Payment>> FindByMusicianIdAsync(int musicianId);
    Task<IEnumerable<Payment>> FindByPromoterIdAsync(int promoterId);
    Task<IEnumerable<Payment>> FindByEventIdAsync(int eventId);
} 