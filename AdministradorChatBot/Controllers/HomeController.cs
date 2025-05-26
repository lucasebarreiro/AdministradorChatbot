using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministradorChatBot.Controllers;

public class HomeController(IChatbotService _chatbotService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateChatbot()
    {
        return View();
    }

    public IActionResult Chat()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateChatbot(Chatbot chatbot)
    {
        if (!ModelState.IsValid)
        {
            return View(chatbot);
        }
        _chatbotService.CreateChatbot(chatbot);

        return RedirectToAction("Index");
    }

}