namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

/// <summary>
/// Value object that represents a location for an event
/// </summary>
/// <param name="Venue">The venue name</param>
/// <param name="Address">The street address</param>
/// <param name="City">The city name</param>
/// <param name="State">The state or region</param>
/// <param name="Country">The country name</param>
public record EventLocation(string Venue, string Address, string City, string State, string Country)
{
    public EventLocation() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty) { }
    
    public string FullAddress => $"{Venue}, {Address}, {City}, {State}, {Country}";
} 