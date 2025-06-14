namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources;

public record EvaluationResource(
    int Id,
    int EventId,
    int Rating,
    string Comment,
    string Type,
    string Status,
    int? MusicianId,
    int? PromoterId,
    List<ChecklistItemResource>? ArtistChecklist,
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

public record ChecklistItemResource(
    string Id,
    string Label,
    bool Value
);