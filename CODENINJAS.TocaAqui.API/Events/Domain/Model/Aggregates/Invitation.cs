using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;

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
        Status = "pending";
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
        Status = command.Status;
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
    public string Status { get; private set; } // pending, accepted, rejected
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Domain methods
    public void Accept()
    {
        Status = "accepted";
        UpdatedAt = DateTime.UtcNow;
    }

    public void Reject()
    {
        Status = "rejected";
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateStatus(string status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }

    public bool IsPending => Status == "pending";
    public bool IsAccepted => Status == "accepted";
    public bool IsRejected => Status == "rejected";
} 
