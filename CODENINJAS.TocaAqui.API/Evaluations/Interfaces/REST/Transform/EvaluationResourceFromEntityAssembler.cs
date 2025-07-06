using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Transform
{
    public static class EvaluationResourceFromEntityAssembler
    {
        public static EvaluationResource ToResourceFromEntity(Evaluation entity)
        {
            return new EvaluationResource(
                entity.Id,
                entity.EventId,
                entity.MusicianId,
                entity.PromoterId,
                entity.Type,
                entity.Status,
                entity.Rating,
                entity.Comment,
                entity.VenueRating,
                entity.VenueComment,
                entity.ArtistRating,
                entity.ArtistComment,
                entity.Checklist,
                entity.ArtistChecklist,
                entity.CreatedAt
            );
        }
    }
}
