using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Payments.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Payments.Domain.Services;

namespace CODENINJAS.TocaAqui.API.Payments.Application.Internal.QueryServices;

/// <summary>
///     Payment query service implementation
/// </summary>
public class PaymentQueryService : IPaymentQueryService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentQueryService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await _paymentRepository.FindByIdAsync(query.PaymentId);
    }

    public async Task<IEnumerable<Payment>> Handle(GetPaymentsByUserIdQuery query)
    {
        return query.UserRole.ToLower() switch
        {
            "musico" or "musician" => await _paymentRepository.FindByMusicianIdAsync(query.UserId),
            "promotor" or "promoter" => await _paymentRepository.FindByPromoterIdAsync(query.UserId),
            _ => new List<Payment>()
        };
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await _paymentRepository.ListAsync();
    }
} 