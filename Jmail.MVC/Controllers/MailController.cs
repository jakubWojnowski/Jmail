using Jmail.Application.MessageDto;
using Jmail.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jmail.MVC.Controllers;

public class MailController : Controller
{
    private readonly IMessageService _service;

    public MailController(IMessageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ViewResult> Index()
    {
        var mails = await _service.GetAll();
        return View(mails);
    }

    [HttpGet]
    public IActionResult SendMessage()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(SendMessageDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _service.SendMessage(dto);
        return RedirectToAction(nameof(Index));
    }
}