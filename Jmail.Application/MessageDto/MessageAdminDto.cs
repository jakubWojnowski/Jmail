namespace Jmail.Application.MessageDto;

public class MessageAdminDto
{
    public string Title { get; set; }
    public string SenderEmail { get; set; }
    public string RecipientEmail { get; set; }
    public string? CreatedById { get; set; }
    public string Content { get; set; }
    public bool isSeeable { get; set; }

    public DateTime CreationDateTime { get; set; }
}