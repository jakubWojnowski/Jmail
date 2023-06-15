using Jmail.Application.MessageDto;
using MediatR;

namespace Jmail.Application.AdminPanel.Queries;

public class GetAllMessagesQuery : IRequest<IEnumerable<MessageAdminDto>>
{
    
}