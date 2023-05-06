using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;

namespace Jmail.Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly JmailDbContext _dbContext;

    public MessageRepository(JmailDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SendMessage(Message message)
    {
        _dbContext.Add(message);
        await _dbContext.SaveChangesAsync();
    }
}