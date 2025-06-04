using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministradorChatBot.Controllers;

public class HomeController(IChatbotService _chatbotService) : Controller
{
    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("Id");
        if (userId == null)
        {
            return RedirectToAction("Login", "Auth");
        }
        var chatbots = _chatbotService.GetChatbotsByUserIdAsync(userId.Value).Result;
        return View(chatbots);
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

    public async Task<IActionResult> EditarChatbot(int id)
    {
        var chatbot = await _chatbotService.GetChatbotWithKeywordsAndResponsesAsync(id);
        if (chatbot == null)
        {
            return NotFound();
        }
        return View("EditarChatbot", chatbot);
    }
    [HttpPost]
    public IActionResult EditarChatbot(Chatbot chatbot)
    {
        if (!ModelState.IsValid)
        {
            return View(chatbot);
        }
        _chatbotService.UpdateChatbot(chatbot);
        return RedirectToAction("Index");
    }

    public IActionResult EliminarChatbot(int id)
    {
        var chatbot = _chatbotService.GetChatbotWithKeywordsAndResponsesAsync(id).Result;
        if (chatbot == null)
        {
            return NotFound();
        }

        _chatbotService.DeleteChatbotAsync(chatbot).Wait();
        return RedirectToAction("Index");
    }

}