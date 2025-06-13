using System.Text.Json;
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

    public async Task<IActionResult> Chat(int id)
    {
        var chatbot = await _chatbotService.GetChatbotWithKeywordsAndResponsesAsync(id);
        if (chatbot == null)
            return NotFound();

        ViewBag.ChatHistory = _chatbotService.GetChatHistory(id, HttpContext.Session);
        return View(chatbot);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(int chatbotId, string userMessage)
    {
        var chatbot = await _chatbotService.GetChatbotWithKeywordsAndResponsesAsync(chatbotId);

        var history = _chatbotService.GetChatHistory(chatbotId, HttpContext.Session);
        history.Add(new ChatMessage { Sender = "Tú", Message = userMessage });

        var responseText = _chatbotService.GetChatbotResponse(chatbot, userMessage);

        history.Add(new ChatMessage { Sender = "Chatbot", Message = responseText });
        _chatbotService.SaveChatHistory(chatbotId, history, HttpContext.Session);

        ViewBag.ChatHistory = history;
        return View("Chat", chatbot);
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