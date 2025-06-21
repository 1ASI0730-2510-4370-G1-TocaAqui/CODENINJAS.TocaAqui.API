using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Queries;

namespace CODENINJAS.TocaAqui.API.Payments.Domain.Services;

/// <summary>
///     Payment query service interface
/// </summary>
public interface IPaymentQueryService
{
    /// <summary>
    ///     Handle get payment by ID query
    /// </summary>
    /// <param name="query">Get payment by ID query</param>
    /// <returns>Payment if found</returns>
    Task<Payment?> Handle(GetPaymentByIdQuery query);
    
    /// <summary>
    ///     Handle get payments by user ID query
    /// </summary>
    /// <param name="query">Get payments by user ID query</param>
    /// <returns>List of payments</returns>
    Task<IEnumerable<Payment>> Handle(GetPaymentsByUserIdQuery query);
    
    /// <summary>
    ///     Handle get all payments query
    /// </summary>
    /// <param name="query">Get all payments query</param>
    /// <returns>List of all payments</returns>
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
} 