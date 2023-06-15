using AutoMapper;
using Jmail.Domain.Interfaces;
using MediatR;

namespace Jmail.Application.Jmail.Queries.GetAllEmails;

public class GetAllEmailsQueryHandler : IRequestHandler<GetAllEmailsQuery, IEnumerable<MessageDto.MessageDto>>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public GetAllEmailsQueryHandler(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MessageDto.MessageDto>> Handle(GetAllEmailsQuery request, CancellationToken cancellationToken)
    {
        var messages = await _messageRepository.GetAllMessages();
        var dtos = _mapper.Map<IEnumerable<MessageDto.MessageDto>>(messages);
        return dtos;
    }
}