using AutoMapper;
using Jmail.Application.AccountDto;
using Jmail.Domain.Entities;

namespace Jmail.Application.Mappings;

public class JmailMappingProfile : Profile
{
    public JmailMappingProfile()
    {
        CreateMap<RegisterAccountDto, Account>();
    }
}