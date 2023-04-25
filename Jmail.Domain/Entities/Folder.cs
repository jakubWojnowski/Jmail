namespace Jmail.Domain.Entities;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Message> Messages { get; set; }
}