using Microsoft.AspNetCore.Identity;

namespace Jmail.Domain.Entities;

public class Message
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? SenderEmail { get; set; }
    public string? ReciptientEmail { get; set; }
    public string? Content { get; set; }
   public int AccountId { get; set; }
    
    public IdentityUser Account { get; set; }
    public List<Folder>? Folders { get; set; }
}