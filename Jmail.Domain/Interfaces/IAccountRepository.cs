using Microsoft.AspNetCore.Identity;

namespace Jmail.Domain.Interfaces;

public interface IAccountRepository
{
    Task<IdentityUser?> GetByEmailName(string email);
}