using MediatR;

namespace Jmail.Application.AdminPanel.Queries;

public class GetAllAccountQuery : IRequest<IEnumerable<AccountDto.AccountDto>>
{
    
}