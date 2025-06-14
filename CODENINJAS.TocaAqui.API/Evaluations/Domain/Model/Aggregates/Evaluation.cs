using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

public partial class Evaluation
{
    public int Id { get; set; }

    // Comunes
    public int EventId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public string Type { get; set; } // "artist" o "venue"
    public string Status { get; set; }

    // Artist Evaluation (opcional)
    public int? MusicianId { get; set; }
    public int? PromoterId { get; set; }
    public List<ChecklistItem>? ArtistChecklist { get; set; }

    // Venue Evaluation (opcional)
    public int? UserId { get; set; }
    public string? Suggestions { get; set; }
    public string? EventName { get; set; }
    public string? EventDate { get; set; }
    public string? EventLocation { get; set; }
    public string? EventImageUrl { get; set; }
    public string? Name { get; set; }
    public string? Date { get; set; }
    public string? Location { get; set; }
    public string? ImageUrl { get; set; }
    
    public Evaluation() { }
    
    public Evaluation(CreateEvaluationCommand command)
    {
        // Comunes
        EventId = command.EventId;
        Rating = command.Rating;
        Comment = command.Comment;
        Type = command.Type;
        Status = command.Status;

        // Artist Evaluation (opcional)
        MusicianId = command.MusicianId;
        PromoterId = command.PromoterId;
        ArtistChecklist = command.ArtistChecklist;

        // Venue Evaluation (opcional)
        UserId = command.UserId;
        Suggestions = command.Suggestions;
        EventName = command.EventName;
        EventDate = command.EventDate;
        EventLocation = command.EventLocation;
        EventImageUrl = command.EventImageUrl;
        Name = command.Name;
        Date = command.Date;
        Location = command.Location;
        ImageUrl = command.ImageUrl;
    }
}



