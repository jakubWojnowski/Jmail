using Jmail.Application.MessageDto;
using MimeKit;

namespace Jmail.Application.Services;

public interface IMessageService
{
    
    public Task<List<MimeMessage>> ReceiveMessage();
    
}