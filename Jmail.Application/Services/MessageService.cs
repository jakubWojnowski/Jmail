using System.Net.Mail;

using AutoMapper;
using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace Jmail.Application.Services;

public class MessageService : IMessageService
{
    public IConfiguration Configuration { get; }
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper, IConfiguration configuration)
    {
        Configuration = configuration;
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

 

    public async Task<List<MimeMessage>> ReceiveMessage()
    {
        using var client = new ImapClient();
        await client.ConnectAsync("localhost", 25, true);
        //await client.AuthenticateAsync("username", "password");

        var inbox = client.Inbox;
        await inbox.OpenAsync(FolderAccess.ReadOnly);

        var messages = (await inbox.FetchAsync(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId))
            .OrderByDescending(x => x.Date.DateTime)
            .Take(10);
        var result = new List<MimeMessage>();

        foreach (var message in messages)
        {
            var mimeMessage = await inbox.GetMessageAsync(message.UniqueId);
            result.Add(mimeMessage);
        }

        await client.DisconnectAsync(true);
        return result;
    }

  
}