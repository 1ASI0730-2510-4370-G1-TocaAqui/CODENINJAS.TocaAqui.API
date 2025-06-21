using CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.Entities;

/// <summary>
///     Payment status history entity
/// </summary>
public class PaymentStatusHistory
{
    public int Id { get; private set; }
    public int PaymentId { get; private set; }
    public EPaymentStatus Status { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string Comment { get; private set; }
    
    protected PaymentStatusHistory() 
    {
        Comment = string.Empty;
    } // For EF Core
    
    public PaymentStatusHistory(int paymentId, EPaymentStatus status, string comment)
    {
        PaymentId = paymentId;
        Status = status;
        Comment = comment ?? string.Empty;
        Timestamp = DateTime.UtcNow;
    }
} 