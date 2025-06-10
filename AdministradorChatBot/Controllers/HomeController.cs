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

    // CHAT CON EL CHATBOT -------- LOGICA DE HISTORIAL DEL CHAT
    private const string ChatHistorySessionKey = "ChatHistory_";

    private List<ChatMessage> GetChatHistory(int chatbotId)
    {
        var key = ChatHistorySessionKey + chatbotId;
        var json = HttpContext.Session.GetString(key);
        return json != null
            ? JsonSerializer.Deserialize<List<ChatMessage>>(json) ?? new List<ChatMessage>()
            : new List<ChatMessage>();
    }

    private void SaveChatHistory(int chatbotId, List<ChatMessage> history)
    {
        var key = ChatHistorySessionKey + chatbotId;
        var json = JsonSerializer.Serialize(history);
        HttpContext.Session.SetString(key, json);
    }

    public async Task<IActionResult> Chat(int id)
    {
        var chatbot = await _chatbotService.GetChatbotWithKeywordsAndResponsesAsync(id);
        if (chatbot == null)
            return NotFound();

        ViewBag.ChatHistory = GetChatHistory(id);
        return View(chatbot);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(int chatbotId, string userMessage)
    {
        var chatbot = await _chatbotService.GetChatbotWithKeywordsAndResponsesAsync(chatbotId);

        var history = GetChatHistory(chatbotId);
        history.Add(new ChatMessage { Sender = "Tú", Message = userMessage });

        var keyword = chatbot?.ChatbotKeywords
            .FirstOrDefault(k => string.Equals(k.Keyword, userMessage, StringComparison.OrdinalIgnoreCase));

        string responseText;
        if (keyword != null && keyword.ChatbotResponses.Any())
        {
            var random = new Random();
            var responses = keyword.ChatbotResponses;
            var randomResponse = responses[random.Next(responses.Count)];
            responseText = randomResponse.Response;
        }
        else
        {
            responseText = "No tengo una respuesta para eso.";
        }

        history.Add(new ChatMessage { Sender = "Chatbot", Message = responseText });
        SaveChatHistory(chatbotId, history);

        ViewBag.ChatHistory = history;
        return View("Chat", chatbot);
    }
    // HASTA ACA LOGICA DEL CHAT E HISTORIAL
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