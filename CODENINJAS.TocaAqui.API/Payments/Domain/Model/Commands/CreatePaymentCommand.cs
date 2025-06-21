namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.Commands;

/// <summary>
///     Command to create a new payment
/// </summary>
/// <param name="EventId">Event ID</param>
/// <param name="MusicianId">Musician ID</param>
/// <param name="PromoterId">Promoter ID</param>
/// <param name="Amount">Payment amount</param>
/// <param name="PaymentMethod">Payment method</param>
/// <param name="BankAccountNumber">Bank account number (if bank transfer)</param>
/// <param name="BankName">Bank name (if bank transfer)</param>
/// <param name="AccountType">Account type (if bank transfer)</param>
/// <param name="Description">Payment description</param>
public record CreatePaymentCommand(
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