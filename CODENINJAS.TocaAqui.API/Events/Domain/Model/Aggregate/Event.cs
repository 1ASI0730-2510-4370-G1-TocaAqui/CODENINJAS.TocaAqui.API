using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;

/// <summary>
/// Event Aggregate - Represents a musical event in the Toca Aquí platform
/// </summary>
public partial class Event
{
    protected Event()
    {
        Name = string.Empty;
        Location = string.Empty;
        ImageUrl = string.Empty;
        Description = string.Empty;
        Requirements = string.Empty;
        Genre = EGenre.Other;
        Equipment = string.Empty;
        EventTime = new EventDateTime();
        SoundcheckTime = new EventDateTime();
        Capacity = 0;
        AvailableTickets = 0;
        Payment = new PaymentInfo();
        Status = EEventStatus.Pending;
        Admin = new EventAdmin();
    }

    public Event(CreateEventCommand command)
    {
        PromoterId = command.PromoterId;
        Name = command.Name;
        EventTime = new EventDateTime(command.Date, command.Time);
        PublishDate = command.PublishDate;
        Location = command.Location;
        ImageUrl = command.ImageUrl;
        Status = EEventStatus.Pending;
        SoundcheckTime = command.SoundcheckDate.HasValue && command.SoundcheckTime.HasValue 
            ? new EventDateTime(command.SoundcheckDate.Value, command.SoundcheckTime.Value)
            : new EventDateTime();
        Capacity = command.Capacity;
        AvailableTickets = command.Capacity;
        Admin = new EventAdmin(command.AdminName, command.AdminContact, command.AdminId);
        Requirements = command.Requirements;
        Description = command.Description;
        Payment = new PaymentInfo(command.Payment);
        Duration = command.Duration;
        Genre = Enum.TryParse<EGenre>(command.Genre, true, out var genre) ? genre : EGenre.Other;
        Equipment = command.Equipment;
    }

    // Properties
    public int Id { get; }
    public int PromoterId { get; private set; }
    public string Name { get; private set; }
    public EventDateTime EventTime { get; private set; }
    public DateTime PublishDate { get; private set; }
    public string Location { get; private set; }
    public string ImageUrl { get; private set; }
    public EEventStatus Status { get; private set; }
    public EventDateTime SoundcheckTime { get; private set; }
    public int Capacity { get; private set; }
    public int AvailableTickets { get; private set; }
    public EventAdmin Admin { get; private set; }
    public string Requirements { get; private set; }
    public string Description { get; private set; }
    public PaymentInfo Payment { get; private set; }
    public int? Duration { get; private set; }
    public EGenre Genre { get; private set; }
    public string Equipment { get; private set; }

    // Domain methods
    public void UpdateEvent(UpdateEventCommand command)
    {
        if (!CanBeModified())
            throw new InvalidOperationException("Event cannot be modified in its current state.");

        Name = command.Name;
        EventTime = new EventDateTime(command.Date, command.Time);
        Location = command.Location;
        Description = command.Description;
        Requirements = command.Requirements;
        Payment = new PaymentInfo(command.Payment);
        Genre = Enum.TryParse<EGenre>(command.Genre, true, out var genre) ? genre : EGenre.Other;
        Equipment = command.Equipment;
        Capacity = command.Capacity;
        AvailableTickets = command.Capacity;
    }

    public void UpdateStatus(EEventStatus newStatus)
    {
        Status = newStatus;
    }

    public bool CanBeModified()
    {
        return Status != EEventStatus.Cancelled && 
               Status != EEventStatus.Completed && 
               EventTime.Date > DateTime.Now;
    }

    public bool HasAvailableTickets()
    {
        return Capacity > 0;
    }

    public void UpdateAdminContact(string newContact)
    {
        Admin.UpdateContact(newContact);
    }
} 