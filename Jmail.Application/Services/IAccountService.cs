using Jmail.Application.AccountDto;

namespace Jmail.Application.Services;

public interface IAccountService
{
    Task Register(RegisterAccountDto dto);
}