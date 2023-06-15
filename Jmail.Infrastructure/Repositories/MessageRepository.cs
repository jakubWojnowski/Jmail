using Jmail.Application.ApplicationUser;
using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Jmail.Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly JmailDbContext _dbContext;
    private readonly IUserContext _userContext;

    public MessageRepository(JmailDbContext dbContext,  IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    public async Task SendMessage(Message message)
    {
        _dbContext.Add(message);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Message>> GetAllMessages() => await _dbContext.Messages.Where(m => m.RecipientEmail == _userContext.GetCurrentUser().Email).ToListAsync();
    public async Task<IEnumerable<Message>> GetEveryMessage() => await _dbContext.Messages.ToListAsync();
     

}