using AutoMapper;
using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;

namespace Jmail.Application.Mappings;

public class JmailMappingProfile : Profile
{
    public JmailMappingProfile()
    {

        CreateMap<SendMessageDto, Message>();
    }
}