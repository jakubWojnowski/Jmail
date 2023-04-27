using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;

namespace Jmail.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly JmailDbContext _dbContext;

    public AccountRepository(JmailDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Register(Account account)
    {
        _dbContext.Add(account);
        await _dbContext.SaveChangesAsync();
    }
}