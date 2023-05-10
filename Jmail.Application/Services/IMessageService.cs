using Jmail.Application.MessageDto;
using MimeKit;

namespace Jmail.Application.Services;

public interface IMessageService
{
    Task SendMessage(SendMessageDto dto);
    public Task<List<MimeMessage>> ReceiveMessage();
    public Task<IEnumerable<MessageDto.MessageDto>> GetAll();
}