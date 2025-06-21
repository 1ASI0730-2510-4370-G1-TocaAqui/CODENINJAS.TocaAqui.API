using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;

/// <summary>
///     Command to create an evaluation (either artist or venue)
/// </summary>
public record CreateEvaluationCommand(
    // Comunes
    int EventId,
    int Rating,
    string Comment,
    string Type,          // "artist" o "venue"
    string Status,        // "evaluated", etc.

    // Artist Evaluation (opcional)
    int? MusicianId,
    int? PromoterId,
    List<ChecklistItem>? ArtistChecklist,

    // Venue Evaluation (opcional)
    int? UserId,
    string? Suggestions,
    string? EventName,
    string? EventDate,
    string? EventLocation,
    string? EventImageUrl,
    string? Name,
    string? Date,
    string? Location,
    string? ImageUrl
);

