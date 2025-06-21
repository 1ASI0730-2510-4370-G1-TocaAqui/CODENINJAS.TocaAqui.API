using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler to convert Payment entity to PaymentResource
/// </summary>
public static class PaymentResourceFromEntityAssembler
{
    /// <summary>
    ///     Convert Payment entity to PaymentResource
    /// </summary>
    /// <param name="entity">Payment entity</param>
    /// <returns>PaymentResource</returns>
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Id,
            entity.EventId,
            entity.MusicianId,
            entity.PromoterId,
            entity.Amount.Value,
            entity.Amount.Currency,
            entity.Status.ToString(),
            entity.PaymentMethod.Method,
            entity.PaymentMethod.BankInfo != null 
                ? new PaymentBankInfoResource(
                    entity.PaymentMethod.BankInfo.AccountNumber,
                    entity.PaymentMethod.BankInfo.BankName,
                    entity.PaymentMethod.BankInfo.AccountType
                )
                : null,
            entity.Description,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.StatusHistory.Select(h => new PaymentStatusHistoryResource(
                h.Id,
                h.Status.ToString(),
                h.Timestamp,
                h.Comment
            ))
        );
    }
} 