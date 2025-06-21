using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;

/// <summary>
///     Payment aggregate root
/// </summary>
public class Payment
{
    public int Id { get; private set; }
    public int EventId { get; private set; }
    public int MusicianId { get; private set; }
    public int PromoterId { get; private set; }
    public PaymentAmount Amount { get; private set; }
    public EPaymentStatus Status { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    
    // Shadow properties for EF Core
    public string? BankAccountNumber { get; private set; }
    public string? BankName { get; private set; }
    public string? BankAccountType { get; private set; }
    public string Currency { get; private set; } = "PEN";
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    private readonly List<PaymentStatusHistory> _statusHistory;
    public IReadOnlyList<PaymentStatusHistory> StatusHistory => _statusHistory.AsReadOnly();
    
    protected Payment() 
    { 
        _statusHistory = new List<PaymentStatusHistory>();
        Amount = new PaymentAmount();
        PaymentMethod = new PaymentMethod();
        Description = string.Empty;
    } // For EF Core
    
    public Payment(int eventId, int musicianId, int promoterId, PaymentAmount amount, 
        PaymentMethod paymentMethod, string description)
    {
        EventId = eventId;
        MusicianId = musicianId;
        PromoterId = promoterId;
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        PaymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
        Description = description ?? string.Empty;
        Status = EPaymentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Currency = amount.Currency;
        
        // Set bank info if available
        if (paymentMethod.BankInfo != null)
        {
            BankAccountNumber = paymentMethod.BankInfo.AccountNumber;
            BankName = paymentMethod.BankInfo.BankName;
            BankAccountType = paymentMethod.BankInfo.AccountType;
        }
        
        _statusHistory = new List<PaymentStatusHistory>();
        AddStatusHistoryEntry(EPaymentStatus.Pending, "Payment created");
    }
    
    public void UpdateStatus(EPaymentStatus newStatus, string comment = "")
    {
        if (Status == newStatus) return;
        
        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
        AddStatusHistoryEntry(newStatus, comment);
    }
    
    public void Hold(string comment = "Payment held")
    {
        if (Status != EPaymentStatus.Pending)
            throw new InvalidOperationException("Can only hold pending payments");
        
        UpdateStatus(EPaymentStatus.Held, comment);
    }
    
    public void Complete(string comment = "Payment completed")
    {
        if (Status != EPaymentStatus.Held && Status != EPaymentStatus.Pending)
            throw new InvalidOperationException("Can only complete pending or held payments");
        
        UpdateStatus(EPaymentStatus.Completed, comment);
    }
    
    public void Cancel(string comment = "Payment cancelled")
    {
        if (Status == EPaymentStatus.Completed)
            throw new InvalidOperationException("Cannot cancel completed payments");
        
        UpdateStatus(EPaymentStatus.Cancelled, comment);
    }
    
    private void AddStatusHistoryEntry(EPaymentStatus status, string comment)
    {
        var historyEntry = new PaymentStatusHistory(Id, status, comment);
        _statusHistory.Add(historyEntry);
    }
} 