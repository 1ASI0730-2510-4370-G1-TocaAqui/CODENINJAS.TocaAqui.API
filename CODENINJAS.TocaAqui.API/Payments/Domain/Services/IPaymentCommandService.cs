using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Payments.Domain.Services;

/// <summary>
///     Payment command service interface
/// </summary>
public interface IPaymentCommandService
{
    /// <summary>
    ///     Handle create payment command
    /// </summary>
    /// <param name="command">Create payment command</param>
    /// <returns>Created payment</returns>
    Task<Payment?> Handle(CreatePaymentCommand command);
    
    /// <summary>
    ///     Handle update payment status command
    /// </summary>
    /// <param name="command">Update payment status command</param>
    /// <returns>Updated payment</returns>
    Task<Payment?> Handle(UpdatePaymentStatusCommand command);
} 