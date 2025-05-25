using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using AdministradorChatBot.Repositories;

namespace AdministradorChatBot.Services;

public class ChatbotService(IChatbotRepository _chatbotRepository) : IChatbotService
{
    public async Task CrearChatbotAsync(ChatbotCreateViewModel model, int userId)
    {
        var chatbot = new Chatbot
        {
            Name = model.Name,
            Description = model.Description,
            UserId = userId
        };

        // Recorre todas las preguntas del formulario
        foreach (var questionVm in model.Questions)
        {
            var keyword = new ChatbotKeyword
            {
                Keyword = questionVm.Question,
                Chatbot = chatbot
            };

            foreach (var answer in questionVm.Answers.Where(a => !string.IsNullOrWhiteSpace(a)))
            {
                keyword.ChatbotResponses.Add(new ChatbotResponse { Response = answer });
            }

            chatbot.ChatbotKeywords.Add(keyword);
        }

        await _chatbotRepository.AddAsync(chatbot);
    }
}