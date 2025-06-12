namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

/// <summary>
///     Command to create a contract between promoter and musician
/// </summary>
/// <param name="EventApplicationId">The ID of the event application</param>
/// <param name="UserId">The ID of the user signing the contract</param>
/// <param name="Content">The content of the contract</param>
/// <param name="Signature">The digital signature</param>
/// <param name="SignedDate">The date when the contract was signed</param>
public record CreateContractCommand(
    int EventApplicationId,
    int UserId,
    string Content,
    string? Signature,
    DateTime? SignedDate
); 
