using AutoMapper;
using Jmail.Application.ApplicationUser;
using Jmail.Application.MessageDto;
using Jmail.Domain.Interfaces;
using MediatR;

namespace Jmail.Application.AdminPanel.Queries;

public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageAdminDto>>
{
  
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetAllMessagesQueryHandler(IMessageRepository messageRepository, IMapper mapper, IUserContext userContext)
    {
        
        _messageRepository = messageRepository;
        _mapper = mapper;
        _userContext = userContext;
    }
    public async Task<IEnumerable<MessageAdminDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        var currentUser =  _userContext.GetCurrentUser();
        if (!currentUser.IsInRole("Admin"))
        {
            throw new Exception("only Admins allowed");
        }
        var messages = await _messageRepository.GetEveryMessage();
        var dtos = _mapper.Map<IEnumerable<MessageAdminDto>>(messages);
        return dtos;
    }
}