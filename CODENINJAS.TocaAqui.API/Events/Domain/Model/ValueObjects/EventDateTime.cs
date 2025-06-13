namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

/// <summary>
/// Value object that represents a date and time for an event
/// </summary>
/// <param name="Date">The date of the event</param>
/// <param name="Time">The time of the event</param>
public record EventDateTime(DateTime Date, TimeSpan Time)
{
    public EventDateTime() : this(DateTime.Now, TimeSpan.Zero) { }

    public DateTime FullDateTime => Date.Add(Time);

    public bool IsValid()
    {
        return Date > DateTime.Now || (Date == DateTime.Now && Time > DateTime.Now.TimeOfDay);
    }
} 