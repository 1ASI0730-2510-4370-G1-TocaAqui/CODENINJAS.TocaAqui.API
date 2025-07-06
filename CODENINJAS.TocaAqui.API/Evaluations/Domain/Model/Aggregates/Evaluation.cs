using System;
using System.Collections.Generic;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates
{
    public class Evaluation
    {
        public int Id { get; private set; }
        public int EventId { get; private set; }
        public int MusicianId { get; private set; }
        public int PromoterId { get; private set; }
        public EEvaluationType Type { get; private set; }
        public EEvaluationStatus Status { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; } = string.Empty;
        public int VenueRating { get; private set; }
        public string VenueComment { get; private set; } = string.Empty;
        public int ArtistRating { get; private set; }
        public string ArtistComment { get; private set; } = string.Empty;
        public List<string> Checklist { get; private set; } = new List<string>();
        public List<string> ArtistChecklist { get; private set; } = new List<string>();
        public DateTime CreatedAt { get; private set; }

        public Evaluation(int eventId, int musicianId, int promoterId, EEvaluationType type, EEvaluationStatus status, int rating, string comment, int venueRating, string venueComment, int artistRating, string artistComment, List<string> checklist, List<string> artistChecklist)
        {
            EventId = eventId;
            MusicianId = musicianId;
            PromoterId = promoterId;
            Type = type;
            Status = status;
            Rating = rating;
            Comment = comment;
            VenueRating = venueRating;
            VenueComment = venueComment;
            ArtistRating = artistRating;
            ArtistComment = artistComment;
            Checklist = checklist ?? new List<string>();
            ArtistChecklist = artistChecklist ?? new List<string>();
            CreatedAt = DateTime.UtcNow;
        }

        // Constructor vacío para EF Core
        public Evaluation() { }
    }
}
