using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;
using CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler to convert UpdatePaymentStatusResource to UpdatePaymentStatusCommand
/// </summary>
public static class UpdatePaymentStatusCommandFromResourceAssembler
{
    /// <summary>
    ///     Convert UpdatePaymentStatusResource to UpdatePaymentStatusCommand
    /// </summary>
    /// <param name="paymentId">Payment ID</param>
    /// <param name="resource">UpdatePaymentStatusResource</param>
    /// <returns>UpdatePaymentStatusCommand</returns>
    public static UpdatePaymentStatusCommand ToCommandFromResource(int paymentId, UpdatePaymentStatusResource resource)
    {
        var status = Enum.Parse<EPaymentStatus>(resource.Status, true);
        
        return new UpdatePaymentStatusCommand(
            paymentId,
            status,
            resource.Comment
        );
    }
} 