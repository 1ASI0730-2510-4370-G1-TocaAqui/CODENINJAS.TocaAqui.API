using CODENINJAS.TocaAqui.API.Events.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Events.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform CreateEventApplicantResource to CreateEventApplicantCommand
/// </summary>
public static class CreateEventApplicantCommandFromResourceAssembler
{
    /// <summary>
    ///     Transform CreateEventApplicantResource to CreateEventApplicantCommand
    /// </summary>
    /// <param name="resource">The CreateEventApplicantResource</param>
    /// <returns>The CreateEventApplicantCommand</returns>
    public static CreateEventApplicantCommand ToCommandFromResource(CreateEventApplicantResource resource)
    {
        return new CreateEventApplicantCommand(
            resource.UserId,
            resource.EventId,
            resource.Status,
            DateTime.UtcNow,
            false, // ContractSigned
            false, // RiderUploaded
            resource.IsInvited
        );
    }
} 
