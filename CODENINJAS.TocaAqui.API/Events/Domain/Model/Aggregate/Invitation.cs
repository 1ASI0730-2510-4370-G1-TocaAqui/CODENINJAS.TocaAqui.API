using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;

/// <summary>
///     Invitation Aggregate - Represents an invitation from a promoter to a musician for an event
/// </summary>
public partial class Invitation
{
    protected Invitation()
    {
        EventName = string.Empty;
        EventLocation = string.Empty;
        EventImageUrl = string.Empty;
        PromoterName = string.Empty;
        ArtistName = string.Empty;
        Message = string.Empty;
        Status = EInvitationStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Constructor for the Invitation aggregate.
    /// </summary>
    /// <param name="command">The CreateInvitationCommand</param>
    public Invitation(CreateInvitationCommand command)
    {
        EventId = command.EventId;
        EventName = command.EventName;
        EventDate = command.EventDate;
        EventLocation = command.EventLocation;
        EventImageUrl = command.EventImageUrl;
        PromoterId = command.PromoterId;
        PromoterName = command.PromoterName;
        ArtistId = command.ArtistId;
        ArtistName = command.ArtistName;
        Message = command.Message;
        Status = Enum.Parse<EInvitationStatus>(command.Status);
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    // Properties
    public int Id { get; }
    public int EventId { get; private set; }
    public string EventName { get; private set; }
    public DateTime EventDate { get; private set; }
    public string EventLocation { get; private set; }
    public string EventImageUrl { get; private set; }
    public int PromoterId { get; private set; }
    public string PromoterName { get; private set; }
    public int ArtistId { get; private set; }
    public string ArtistName { get; private set; }
    public string Message { get; private set; }
    public EInvitationStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Domain methods
    public void UpdateStatus(string status)
    {
        Status = Enum.Parse<EInvitationStatus>(status);
        UpdatedAt = DateTime.UtcNow;
    }

    public void Accept()
    {
        Status = EInvitationStatus.Accepted;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Reject()
    {
        Status = EInvitationStatus.Rejected;
        UpdatedAt = DateTime.UtcNow;
    }

    public bool IsPending => Status == EInvitationStatus.Pending;
    public bool IsAccepted => Status == EInvitationStatus.Accepted;
    public bool IsRejected => Status == EInvitationStatus.Rejected;
} 
