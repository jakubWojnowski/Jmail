using MediatR;

namespace Jmail.Application.Jmail.Queries.GetAllEmails;

public class GetAllEmailsQuery : IRequest<IEnumerable<MessageDto.MessageDto>>
{
    
}