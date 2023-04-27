using Jmail.Domain.Entities;

namespace Jmail.Domain.Interfaces;

public interface IAccountRepository
{
    Task Register(Account account);
}