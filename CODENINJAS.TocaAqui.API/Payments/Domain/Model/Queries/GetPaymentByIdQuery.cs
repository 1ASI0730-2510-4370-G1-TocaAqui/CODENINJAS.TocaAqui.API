namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.Queries;
 
/// <summary>
///     Query to get payment by ID
/// </summary>
/// <param name="PaymentId">Payment ID</param>
public record GetPaymentByIdQuery(int PaymentId); 