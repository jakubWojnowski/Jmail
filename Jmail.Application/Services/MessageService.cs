using System.Net.Mail;

using AutoMapper;
using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
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
        message.From.Add(MailboxAddress.Parse("dereck.gerhold@ethereal.email"));
        message.To.Add(MailboxAddress.Parse(dto.ReciptientEmail));
        message.Subject = dto.Title;
        message.Body = new TextPart(TextFormat.Html) { Text = dto.Content };
        await _messageRepository.SendMessage(contentMessage);
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        await smtpClient.ConnectAsync("smtp.ethereal.email", 587,SecureSocketOptions.StartTls);
        await smtpClient.AuthenticateAsync("dereck.gerhold@ethereal.email","eYF1gaVrBMDHyeTsVH");
        await smtpClient.SendAsync((MimeMessage)message);
        await smtpClient.DisconnectAsync(true);
    }
}