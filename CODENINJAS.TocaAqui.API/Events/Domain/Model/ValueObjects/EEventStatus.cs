namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

/// <summary>
/// Represents the status of an event in the Toca Aquí platform.
/// </summary>
public enum EEventStatus
{
    Pending,
    Approved,
    Rejected,
    Cancelled,
    Completed
} 