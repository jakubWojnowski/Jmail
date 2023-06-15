using MediatR;

namespace Jmail.Application.AdminPanel.Commands;

public class DeleteUserCommand : IRequest<Unit>
{
    public string UserId { get; set; }
}