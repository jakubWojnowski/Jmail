using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace Jmail.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly JmailDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountRepository(JmailDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<IdentityUser?> GetByEmailName(string email) =>  await _userManager.FindByEmailAsync(email.ToLower());

   
}