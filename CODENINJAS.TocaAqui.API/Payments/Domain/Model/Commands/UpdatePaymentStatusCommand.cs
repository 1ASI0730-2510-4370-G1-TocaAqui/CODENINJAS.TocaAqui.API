using CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.Commands;

/// <summary>
///     Command to update payment status
/// </summary>
/// <param name="PaymentId">Payment ID</param>
/// <param name="Status">New status</param>
/// <param name="Comment">Status change comment</param>
public record UpdatePaymentStatusCommand(
    int PaymentId,
    EPaymentStatus Status,
    string? Comment = null
); 