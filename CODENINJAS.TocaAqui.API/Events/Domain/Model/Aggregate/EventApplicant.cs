using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;

/// <summary>
///     EventApplicant Aggregate - Represents the relationship between a user and an event application
/// </summary>
public partial class EventApplicant
{
    protected EventApplicant()
    {
        Status = EEventApplicantStatus.Pending;
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
        Status = Enum.Parse<EEventApplicantStatus>(command.Status);
        ApplicationDate = command.ApplicationDate;
        ContractSigned = command.ContractSigned;
        RiderUploaded = command.RiderUploaded;
        IsInvited = command.IsInvited;
    }

    // Properties
    public int Id { get; }
    public int UserId { get; private set; }
    public int EventId { get; private set; }
    public EEventApplicantStatus Status { get; private set; }
    public DateTime ApplicationDate { get; private set; }
    public bool ContractSigned { get; private set; }
    public bool RiderUploaded { get; private set; }
    public bool IsInvited { get; private set; }

    // Navigation properties
    public Contract? Contract { get; private set; }
    public RiderTechnical? RiderTechnical { get; private set; }

    // Domain methods
    public void UpdateStatus(string status)
    {
        Status = Enum.Parse<EEventApplicantStatus>(status);
    }

    public void SignContract()
    {
        ContractSigned = true;
        Status = EEventApplicantStatus.Signed;
    }

    public void UploadRider()
    {
        RiderUploaded = true;
    }

    public void AcceptInvitation()
    {
        if (IsInvited && Status == EEventApplicantStatus.Pending)
        {
            Status = EEventApplicantStatus.ContractPending;
        }
    }

    public void RejectApplication()
    {
        Status = EEventApplicantStatus.Rejected;
    }
} 
