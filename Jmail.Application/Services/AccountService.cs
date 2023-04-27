using AutoMapper;
using Jmail.Application.AccountDto;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;

namespace Jmail.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
   // private readonly IPasswordHasher<Account> _passwordHasher;

    public AccountService(IAccountRepository accountRepository, IMapper mapper/*,IPasswordHasher<Account> passwordHasher*/)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
      //  _passwordHasher = passwordHasher;
    }

    public async Task Register(RegisterAccountDto dto)
    {
        /*var account = _mapper.Map<Account>(dto);
        
      
        var hashedPassword = _passwordHasher.HashPassword(account, accountDto.Password);

        account.PasswordHash = hashedPassword;*/
      
    }
}