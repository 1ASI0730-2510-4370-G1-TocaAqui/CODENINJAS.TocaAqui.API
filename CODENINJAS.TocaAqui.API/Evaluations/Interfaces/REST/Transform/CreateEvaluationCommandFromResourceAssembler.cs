using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform EvaluationResource to CreateEvaluationCommand
/// </summary>
public static class CreateEvaluationCommandFromResourceAssembler
{
    public static CreateEvaluationCommand ToCommandFromResource(EvaluationResource resource)
    {
        List<ChecklistItem>? checklist = resource.ArtistChecklist?.Select(item =>
            new ChecklistItem(item.Id, item.Label, item.Value)
        ).ToList();

        return new CreateEvaluationCommand(
            resource.EventId,
            resource.Rating,
            resource.Comment,
            resource.Type,
            resource.Status,
            resource.MusicianId,
            resource.PromoterId,
            checklist,
            resource.UserId,
            resource.Suggestions,
            resource.EventName,
            resource.EventDate,
            resource.EventLocation,
            resource.EventImageUrl,
            resource.Name,
            resource.Date,
            resource.Location,
            resource.ImageUrl
        );
    }

}