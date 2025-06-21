namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;

/// <summary>
///     Payment amount value object
/// </summary>
public record PaymentAmount
{
    public decimal Value { get; init; }
    public string Currency { get; init; } = "PEN";
    
    // Constructor sin parámetros para EF Core
    public PaymentAmount() { }
    
    public PaymentAmount(decimal value, string currency = "PEN")
    {
        if (value < 0)
            throw new ArgumentException("Payment amount cannot be negative", nameof(value));
        
        Value = value;
        Currency = currency ?? "PEN";
    }
    
    public static implicit operator decimal(PaymentAmount amount) => amount.Value;
    public static implicit operator PaymentAmount(decimal value) => new(value);
    
    public override string ToString() => $"{Value:C} {Currency}";
} 