using Jmail.Application.AdminPanel.Queries;
using Jmail.Application.Jmail.Commands.CreateEmail;
using Jmail.Application.Jmail.Queries.GetAllEmails;
using Jmail.Application.MessageDto;
using Jmail.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jmail.MVC.Controllers;

public class MailController : Controller
{
    private readonly IMediator _mediator;


    public MailController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetEveryMessage()
    {
        var messageAdmin = await _mediator.Send(new GetAllMessagesQuery());
        return View(messageAdmin);
    }
    [Authorize]
    [HttpGet]
    public async Task<ViewResult> ViewMails()
    {

        var mails = await _mediator.Send(new GetAllEmailsQuery());
        return View(mails);
    }

    
    [Authorize]
    [HttpGet]
    public IActionResult SendMessage()
    {
        /*if (User.Identity == null || !User.Identity.IsAuthenticated )
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }*/
        return View();
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateEmailCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(ViewMails));
    }
}