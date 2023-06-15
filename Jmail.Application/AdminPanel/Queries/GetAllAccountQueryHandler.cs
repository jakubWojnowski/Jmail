using AutoMapper;
using Jmail.Application.ApplicationUser;
using Jmail.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jmail.Application.AdminPanel.Queries;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, IEnumerable<AccountDto.AccountDto>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetAllAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper, IUserContext userContext)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _userContext = userContext;
    }
    public async Task<IEnumerable<AccountDto.AccountDto>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
    {
        var currentUser =  _userContext.GetCurrentUser();
        if (!currentUser.IsInRole("Admin"))
        {
            throw new Exception("only Admins allowed");
        }
        var account = await _accountRepository.GetEveryAccount();
        var dtos = _mapper.Map<IEnumerable<AccountDto.AccountDto>>(account);
        return dtos;
    }
}