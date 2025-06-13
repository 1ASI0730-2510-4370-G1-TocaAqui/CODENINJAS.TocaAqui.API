namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Entities;

public class Evaluation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Evaluation() {}

    public Evaluation(Guid userId, string entityType, Guid entityId, int score, string comment)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EntityType = entityType;
        EntityId = entityId;
        Score = score;
        Comment = comment;
        CreatedAt = DateTime.UtcNow;
    }
}