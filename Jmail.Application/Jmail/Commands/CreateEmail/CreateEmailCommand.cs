using Jmail.Application.MessageDto;
using MediatR;

namespace Jmail.Application.Jmail.Commands.CreateEmail;

public class CreateEmailCommand : SendMessageDto, IRequest
{
    
}