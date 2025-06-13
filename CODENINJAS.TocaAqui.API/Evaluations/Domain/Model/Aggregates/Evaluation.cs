namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

public class Evaluation
{
    public Guid Id { get; private set; }
    public string EntityType { get; private set; } = string.Empty;
    public Guid EntityId { get; private set; }
    public int Score { get; private set; }
    public string? Comment { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Evaluation(Guid commandUserId, string entityType, Guid entityId, int score, string? comment)
    {
        Id = Guid.NewGuid();
        EntityType = entityType;
        EntityId = entityId;
        Score = score;
        Comment = comment;
        CreatedAt = DateTime.UtcNow;
    }
    
    public void Update(int score, string? comment)
    {
        Score = score;
        Comment = comment;
    }
}
