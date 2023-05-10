namespace Jmail.Application.MessageDto;

public class SendMessageDto
{
    public string Title { get; set; }
    public string SenderEmail { get; set; } = "mail@test.com";
    public string RecipientEmail { get; set; }
    public string Content { get; set; }

}