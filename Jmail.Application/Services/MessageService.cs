using System.Net.Mail;

using AutoMapper;
using Jmail.Application.MessageDto;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
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
        var message = new MailMessage();
        var contentMessage = _mapper.Map<Message>(dto);
        message.To.Add(dto.ReciptientEmail);
        message.Subject = dto.Title;
        message.Body = dto.Content;
        await _messageRepository.SendMessage(contentMessage);
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        await smtpClient.ConnectAsync(Configuration.GetSection("Host").Value, 587,SecureSocketOptions.StartTls);
        await smtpClient.AuthenticateAsync(Configuration.GetSection("Username").Value,Configuration.GetSection("Password").Value);
        await smtpClient.SendAsync((MimeMessage)message);
    }
}