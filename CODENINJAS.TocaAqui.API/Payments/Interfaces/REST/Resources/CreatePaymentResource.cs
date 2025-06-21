namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a new payment
/// </summary>
public record CreatePaymentResource(
    int EventId,
    int MusicianId,
    int PromoterId,
    decimal Amount,
    string PaymentMethod,
    string? BankAccountNumber = null,
    string? BankName = null,
    string? AccountType = null,
    string? Description = null
);