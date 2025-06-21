namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;

/// <summary>
///     Payment status value object
/// </summary>
public enum EPaymentStatus
{
    Pending,
    Held,
    Completed,
    Cancelled
} 