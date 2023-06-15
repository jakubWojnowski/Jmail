using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
    public async Task<List<IdentityUser>> GetEveryAccount() => await _userManager.Users.ToListAsync();


    public async Task DeleteAccount(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new KeyNotFoundException(); 
        }
        await _userManager.DeleteAsync(user);
    }

   
}