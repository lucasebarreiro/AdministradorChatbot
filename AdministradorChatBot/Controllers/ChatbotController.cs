using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdministradorChatBot.Controllers
{
    public class ChatbotController : Controller
    {

        private readonly IChatbotService _chatbotService;

        public ChatbotController(IChatbotService chatbotService)
        {
            _chatbotService = chatbotService;
        }


        [HttpGet]
        public IActionResult CrearChatbot()
        {
            return View(new ChatbotCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CrearChatbot(ChatbotCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = 1; // Obtén el usuario actual según tu autenticación

            await _chatbotService.CrearChatbotAsync(model, userId);

            return RedirectToAction("Index");

            
        }

    }
}
