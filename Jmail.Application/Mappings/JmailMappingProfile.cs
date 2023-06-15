using AutoMapper;
using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Jmail.Application.Mappings;

public class JmailMappingProfile : Profile
{
    public JmailMappingProfile()
    {

        CreateMap<SendMessageDto, Message>();
        CreateMap<MessageDto.MessageDto, Message>();
        CreateMap<Message, MessageDto.MessageDto>();
        CreateMap<Message, MessageAdminDto>();
        CreateMap<IdentityUser, AccountDto.AccountDto>()
            .ForMember(a => a.UserName, 
            i => i.MapFrom(i => i.UserName))
            .ForMember(a => a.Email, 
            i => i.MapFrom(i => i.Email))
            .ForMember(a => a.Id, 
                i => i.MapFrom(i => i.Id));
    }
}