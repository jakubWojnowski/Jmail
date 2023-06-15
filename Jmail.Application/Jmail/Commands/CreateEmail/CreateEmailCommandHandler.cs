using AutoMapper;
using Jmail.Application.ApplicationUser;
using Jmail.Domain.Entities;
using Jmail.Domain.Interfaces;
using MailKit.Security;
using MediatR;
using MimeKit;
using MimeKit.Text;

namespace Jmail.Application.Jmail.Commands.CreateEmail;

public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public CreateEmailCommandHandler(IMessageRepository messageRepository, IMapper mapper, IUserContext userContext)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
    {
        var message = new MimeMessage();
        var contentMessage = _mapper.Map<Message>(request);
        message.From.Add(MailboxAddress.Parse(request.SenderEmail));
        message.To.Add(MailboxAddress.Parse(request.RecipientEmail));
        message.Subject = request.Title;
        message.Body = new TextPart(TextFormat.Html) { Text = request.Content };
        contentMessage.CreatedById = _userContext.GetCurrentUser().Id;
        await _messageRepository.SendMessage(contentMessage);
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        await smtpClient.ConnectAsync("localhost", 25,SecureSocketOptions.StartTls);
       // await smtpClient.AuthenticateAsync("dereck.gerhold@ethereal.email","eYF1gaVrBMDHyeTsVH");
        await smtpClient.SendAsync((MimeMessage)message);
        await smtpClient.DisconnectAsync(true);
            
        return Unit.Value;
    }
}