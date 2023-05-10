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

    public async Task SendMessage(SendMessageDto dto)
    {
        var message = new MimeMessage();
        var contentMessage = _mapper.Map<Message>(dto);
        message.From.Add(MailboxAddress.Parse(dto.SenderEmail));
        message.To.Add(MailboxAddress.Parse(dto.RecipientEmail));
        message.Subject = dto.Title;
        message.Body = new TextPart(TextFormat.Html) { Text = dto.Content };
        await _messageRepository.SendMessage(contentMessage);
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        await smtpClient.ConnectAsync("smtp.ethereal.email", 587,SecureSocketOptions.StartTls);
        await smtpClient.AuthenticateAsync("dereck.gerhold@ethereal.email","eYF1gaVrBMDHyeTsVH");
        await smtpClient.SendAsync((MimeMessage)message);
        await smtpClient.DisconnectAsync(true);
    }

    public async Task<List<MimeMessage>> ReceiveMessage()
    {
        using var client = new ImapClient();
        await client.ConnectAsync("dereck.gerhold@ethereal.email", 993, true);
        await client.AuthenticateAsync("username", "password");

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

    public async Task<IEnumerable<MessageDto.MessageDto>> GetAll()
    {
        var messages = await _messageRepository.GetAllMessages();
        var dtos = _mapper.Map<IEnumerable<MessageDto.MessageDto>>(messages);
        return dtos;

    }

}