using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;

/// <summary>
///     Contract Aggregate - Represents a contract between a promoter and musician for an event
/// </summary>
public partial class Contract
{
    protected Contract()
    {
        Content = string.Empty;
    }

    /// <summary>
    ///     Constructor for the Contract aggregate.
    /// </summary>
    /// <param name="command">The CreateContractCommand</param>
    public Contract(CreateContractCommand command)
    {
        EventApplicationId = command.EventApplicationId;
        UserId = command.UserId;
        Content = command.Content;
        Signature = command.Signature;
        SignedDate = command.SignedDate;
    }

    // Properties
    public int Id { get; }
    public int EventApplicationId { get; private set; }
    public int UserId { get; private set; }
    public string Content { get; private set; }
    public string? Signature { get; private set; }
    public DateTime? SignedDate { get; private set; }

    // Domain methods
    public void SignContract(string signature)
    {
        Signature = signature;
        SignedDate = DateTime.UtcNow;
    }

    public void UpdateContent(string content)
    {
        Content = content;
    }

    public bool IsSigned => !string.IsNullOrEmpty(Signature) && SignedDate.HasValue;
} 