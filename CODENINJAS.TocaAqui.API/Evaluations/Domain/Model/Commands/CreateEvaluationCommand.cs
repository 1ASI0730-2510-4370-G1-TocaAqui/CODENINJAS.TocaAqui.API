namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;

public class CreateEvaluationCommand
{
    public Guid UserId { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; } = string.Empty;

    public CreateEvaluationCommand() {}

    public CreateEvaluationCommand(Guid userId, string entityType, Guid entityId, int score, string comment)
    {
        UserId = userId;
        EntityType = entityType;
        EntityId = entityId;
        Score = score;
        Comment = comment;
    }
}