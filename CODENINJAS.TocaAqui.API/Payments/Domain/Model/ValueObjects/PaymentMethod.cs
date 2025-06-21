namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;

/// <summary>
///     Payment method value object
/// </summary>
public record PaymentMethod
{
    public string Method { get; init; } = string.Empty;
    public BankInfo? BankInfo { get; init; }
    
    // Constructor sin parámetros para EF Core
    public PaymentMethod() { }
    
    public PaymentMethod(string method, BankInfo? bankInfo = null)
    {
        Method = method ?? throw new ArgumentNullException(nameof(method));
        BankInfo = bankInfo;
    }
    
    public static PaymentMethod BankTransfer(BankInfo bankInfo) => new("bank_transfer", bankInfo);
    public static PaymentMethod CreditCard() => new("credit_card");
    public static PaymentMethod DebitCard() => new("debit_card");
    public static PaymentMethod Cash() => new("cash");
}

/// <summary>
///     Bank information value object
/// </summary>
public record BankInfo(string AccountNumber, string BankName, string AccountType); 