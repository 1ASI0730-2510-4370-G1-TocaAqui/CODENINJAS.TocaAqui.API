using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;

/// <summary>
///     Event Aggregate - Represents a musical event in the Toca Aquí platform
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
        Equipment = string.Empty;
        AdminName = string.Empty;
        AdminContact = string.Empty;
        Status = EEventStatus.Pending;
        Genre = EMusicGenre.Other;
    }

    /// <summary>
    ///     Constructor for the Event aggregate.
    /// </summary>
    /// <remarks>
    ///     The constructor acts as the command handler for the CreateEventCommand.
    /// </remarks>
    /// <param name="command">The CreateEventCommand</param>
    public Event(CreateEventCommand command)
    {
        PromoterId = command.PromoterId;
        Name = command.Name;
        Date = command.Date;
        Time = TimeSpan.Parse(command.Time);
        PublishDate = command.PublishDate;
        Location = command.Location;
        ImageUrl = command.ImageUrl;
        Status = Enum.Parse<EEventStatus>(command.Status);
        SoundcheckDate = command.SoundcheckDate;
        SoundcheckTime = !string.IsNullOrEmpty(command.SoundcheckTime) ? TimeSpan.Parse(command.SoundcheckTime) : null;
        Capacity = command.Capacity;
        AdminName = command.AdminName;
        AdminId = command.AdminId;
        AdminContact = command.AdminContact;
        Requirements = command.Requirements;
        Description = command.Description;
        Payment = command.Payment;
        Duration = command.Duration;
        Genre = Enum.Parse<EMusicGenre>(command.Genre);
        Equipment = command.Equipment;
    }

    // Properties
    public int Id { get; }
    public int? PromoterId { get; private set; }
    public string Name { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public DateTime PublishDate { get; private set; }
    public string Location { get; private set; }
    public string ImageUrl { get; private set; }
    public EEventStatus Status { get; private set; }
    public DateTime? SoundcheckDate { get; private set; }
    public TimeSpan? SoundcheckTime { get; private set; }
    public int Capacity { get; private set; }
    public string AdminName { get; private set; }
    public int? AdminId { get; private set; }
    public string AdminContact { get; private set; }
    public string Requirements { get; private set; }
    public string Description { get; private set; }
    public decimal Payment { get; private set; }
    public int? Duration { get; private set; }
    public EMusicGenre Genre { get; private set; }
    public string Equipment { get; private set; }

    // Domain methods
    public void Update(UpdateEventCommand command)
    {
        Name = command.Name;
        Date = command.Date;
        Time = TimeSpan.Parse(command.Time);
        Location = command.Location;
        ImageUrl = command.ImageUrl;
        Status = Enum.Parse<EEventStatus>(command.Status);
        SoundcheckDate = command.SoundcheckDate;
        SoundcheckTime = !string.IsNullOrEmpty(command.SoundcheckTime) ? TimeSpan.Parse(command.SoundcheckTime) : null;
        Capacity = command.Capacity;
        AdminName = command.AdminName;
        AdminId = command.AdminId;
        AdminContact = command.AdminContact;
        Requirements = command.Requirements;
        Description = command.Description;
        Payment = command.Payment;
        Duration = command.Duration;
        Genre = Enum.Parse<EMusicGenre>(command.Genre);
        Equipment = command.Equipment;
    }

    public void UpdateStatus(string status)
    {
        Status = Enum.Parse<EEventStatus>(status);
    }
} 
