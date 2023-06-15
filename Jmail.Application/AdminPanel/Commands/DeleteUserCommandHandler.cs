using Jmail.Application.ApplicationUser;
using Jmail.Domain.Interfaces;
using MediatR;

namespace Jmail.Application.AdminPanel.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserContext _userContext;


    public DeleteUserCommandHandler(IAccountRepository accountRepository, IUserContext userContext)
    {
        _accountRepository = accountRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        if (!currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }
        await _accountRepository.DeleteAccount(request.UserId);
        return Unit.Value;
    }
}