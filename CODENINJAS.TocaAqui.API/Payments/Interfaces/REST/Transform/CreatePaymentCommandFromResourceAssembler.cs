using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler to convert CreatePaymentResource to CreatePaymentCommand
/// </summary>
public static class CreatePaymentCommandFromResourceAssembler
{
    /// <summary>
    ///     Convert CreatePaymentResource to CreatePaymentCommand
    /// </summary>
    /// <param name="resource">CreatePaymentResource</param>
    /// <returns>CreatePaymentCommand</returns>
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(
            resource.EventId,
            resource.MusicianId,
            resource.PromoterId,
            resource.Amount,
            resource.PaymentMethod,
            resource.BankAccountNumber,
            resource.BankName,
            resource.AccountType,
            resource.Description
        );
    }
}