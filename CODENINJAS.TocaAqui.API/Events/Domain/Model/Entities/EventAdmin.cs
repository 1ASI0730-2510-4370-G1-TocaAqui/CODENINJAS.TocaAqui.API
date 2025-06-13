namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;

/// <summary>
/// Represents an administrator for an event
/// </summary>
public class EventAdmin
{
    public int? Id { get; private set; }
    public string Name { get; private set; }
    public string Contact { get; private set; }

    public EventAdmin()
    {
        Name = string.Empty;
        Contact = string.Empty;
    }

    public EventAdmin(string name, string contact, int? id = null)
    {
        Name = name;
        Contact = contact;
        Id = id;
    }

    public void UpdateContact(string newContact)
    {
        Contact = newContact;
    }
} 