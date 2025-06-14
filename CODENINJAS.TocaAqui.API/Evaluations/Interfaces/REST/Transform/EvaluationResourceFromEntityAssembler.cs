using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Transform;

/// <summary>
///     Assembler to transform Evaluation entity to EvaluationResource
/// </summary>
public static class EvaluationResourceFromEntityAssembler
{
    public static EvaluationResource ToResourceFromEntity(Evaluation entity)
    {
        var artistChecklist = entity.ArtistChecklist?
            .Select(item => new ChecklistItemResource(
                item.Id,
                item.Label,
                item.Value
            )).ToList();

        return new EvaluationResource(
            entity.Id,
            entity.EventId,
            entity.Rating,
            entity.Comment,
            entity.Type,
            entity.Status,
            entity.MusicianId,
            entity.PromoterId,
            artistChecklist,
            entity.UserId,
            entity.Suggestions,
            entity.EventName,
            entity.EventDate,
            entity.EventLocation,
            entity.EventImageUrl,
            entity.Name,
            entity.Date,
            entity.Location,
            entity.ImageUrl
        );
    }
}