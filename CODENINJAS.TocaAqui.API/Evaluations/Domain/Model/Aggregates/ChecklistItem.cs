namespace CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

public class ChecklistItem
{
    public string Id { get; set; }
    public string Label { get; set; }
    public bool Value { get; set; }

    public ChecklistItem(string id, string label, bool value)
    {
        Id = id;
        Label = label;
        Value = value;
    }

    // Constructor vacío por si lo requiere EF Core
    public ChecklistItem() { }
}
