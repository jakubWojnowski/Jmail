using Microsoft.AspNetCore.Identity;

namespace Jmail.Domain.Entities;

public class Message
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string SenderEmail { get; set; }
    public string RecipientEmail { get; set; }
    
    public DateTime CreationDateTime { get; set; }

    public Message()
    {
        CreationDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
    }
    
}