namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;

/// <summary>
///     Resource for updating payment status
/// </summary>
public record UpdatePaymentStatusResource(
    string Status,
    string? Comment = null
); 