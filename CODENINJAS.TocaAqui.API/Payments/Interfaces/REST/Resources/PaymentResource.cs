namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;

/// <summary>
///     Payment resource for API responses
/// </summary>
public record PaymentResource(
    int Id,
    int EventId,
    int MusicianId,
    int PromoterId,
    decimal Amount,
    string Currency,
    string Status,
    string PaymentMethod,
    PaymentBankInfoResource? BankInfo,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    IEnumerable<PaymentStatusHistoryResource> StatusHistory
);

/// <summary>
///     Payment bank info resource
/// </summary>
public record PaymentBankInfoResource(
    string AccountNumber,
    string BankName,
    string AccountType
);

/// <summary>
///     Payment status history resource
/// </summary>
public record PaymentStatusHistoryResource(
    int Id,
    string Status,
    DateTime Timestamp,
    string Comment
);