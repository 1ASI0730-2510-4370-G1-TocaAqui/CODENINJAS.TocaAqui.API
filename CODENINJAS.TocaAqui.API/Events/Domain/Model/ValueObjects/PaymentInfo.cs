namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

/// <summary>
/// Value object that represents payment information for an event
/// </summary>
/// <param name="Amount">The payment amount</param>
/// <param name="Currency">The currency code (default: PEN)</param>
public record PaymentInfo(decimal Amount, string Currency = "PEN")
{
    public PaymentInfo() : this(0, "PEN") { }

    public bool IsValid()
    {
        return Amount >= 0;
    }

    public string FormattedAmount => $"{Currency} {Amount:N2}";
} 