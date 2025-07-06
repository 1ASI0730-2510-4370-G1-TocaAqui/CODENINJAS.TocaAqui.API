using System;
using System.Collections.Generic;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources
{
    public record EvaluationResource(
        int Id,
        int EventId,
        int MusicianId,
        int PromoterId,
        EEvaluationType Type,
        EEvaluationStatus Status,
        int Rating,
        string Comment,
        int VenueRating,
        string VenueComment,
        int ArtistRating,
        string ArtistComment,
        List<string> Checklist,
        List<string> ArtistChecklist,
        DateTime CreatedAt
    );
}
