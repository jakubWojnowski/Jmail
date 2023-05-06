using Jmail.Application.MessageDto;

namespace Jmail.Application.Services;

public interface IMessageService
{
    Task SendMessage(SendMessageDto dto);
}