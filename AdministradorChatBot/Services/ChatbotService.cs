using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

namespace AdministradorChatBot.Services;

public class ChatbotService(IChatbotRepository _chatbotRepository) : IChatbotService
{
    public async Task CreateChatbot(Chatbot chatbot)
    {
        await _chatbotRepository.CreateChatbotAsync(chatbot);
    }

    public Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId)
    {
        throw new NotImplementedException();
    }
}
