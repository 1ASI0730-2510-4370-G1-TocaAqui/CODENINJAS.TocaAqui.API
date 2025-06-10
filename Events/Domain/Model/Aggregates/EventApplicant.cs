using tocaaqui_backend.Events.Domain.Model.Commands;

namespace tocaaqui_backend.Events.Domain.Model.Aggregates;

/// <summary>
///     EventApplicant Aggregate - Represents the relationship between a user and an event application
/// </summary>
public partial class EventApplicant
{
    protected EventApplicant()
    {
        Status = "pending";
        ApplicationDate = DateTime.UtcNow;
    }

    /// <summary>
    ///     Constructor for the EventApplicant aggregate.
    /// </summary>
    /// <param name="command">The CreateEventApplicantCommand</param>
    public EventApplicant(CreateEventApplicantCommand command)
    {
        UserId = command.UserId;
        EventId = command.EventId;
        Status = command.Status;
        ApplicationDate = command.ApplicationDate;
        ContractSigned = command.ContractSigned;
        RiderUploaded = command.RiderUploaded;
        IsInvited = command.IsInvited;
    }

    // Properties
    public int Id { get; }
    public int UserId { get; private set; }
    public int EventId { get; private set; }
    public string Status { get; private set; } // pending, contract_pending, signed, rejected
    public DateTime ApplicationDate { get; private set; }
    public bool ContractSigned { get; private set; }
    public bool RiderUploaded { get; private set; }
    public bool IsInvited { get; private set; } // Indicates if the application comes from an invitation

    // Domain methods
    public void UpdateStatus(string status)
    {
        Status = status;
    }

    public void SignContract()
    {
        ContractSigned = true;
        Status = "signed";
    }

    public void UploadRider()
    {
        RiderUploaded = true;
    }

    public void AcceptInvitation()
    {
        if (IsInvited && Status == "pending")
        {
            Status = "contract_pending";
        }
    }

    public void RejectApplication()
    {
        Status = "rejected";
    }
} 
