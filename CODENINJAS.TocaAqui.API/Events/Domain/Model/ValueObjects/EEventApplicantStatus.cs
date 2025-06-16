namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.ValueObjects;

/// <summary>
///     Representa el estado de una aplicación a un evento en la plataforma Toca Aquí
/// </summary>
public enum EEventApplicantStatus
{
    Pending,
    ContractPending,
    Signed,
    Rejected
} 