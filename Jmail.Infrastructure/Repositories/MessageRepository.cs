using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Message>> GetAllMessages() => await _dbContext.Messages.ToListAsync();

}