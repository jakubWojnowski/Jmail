using FluentValidation;
using Jmail.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Jmail.Application.MessageDto;

public class SendMessageValidator : AbstractValidator<SendMessageDto>
{
    
    private readonly IAccountRepository _accountRepository;

    public SendMessageValidator( IAccountRepository accountRepository)
    {
        
        _accountRepository = accountRepository;

        RuleFor(m => m.RecipientEmail)
            .NotEmpty()
            .EmailAddress();
            /*.Custom((value, context) =>
            {
                var emailAddressExisting = _accountRepository.GetByEmailName(value).Result;
                if (emailAddressExisting == null)
                {
                    context.AddFailure($"{value} doesnt exist");
                }

            })*/
        RuleFor(m => m.Title)
            .NotEmpty()
            .MaximumLength(30).WithMessage("title should have max 30 characters");
        RuleFor(m => m.Content)
            .MaximumLength(2000);
    }
}