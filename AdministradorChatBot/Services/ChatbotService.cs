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
        return _chatbotRepository.GetChatbotsByUserIdAsync(userId);
    }

    public Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId)
    {
        return _chatbotRepository.GetChatbotWithKeywordsAndResponsesAsync(chatbotId);
    }

    public void UpdateChatbot(Chatbot chatbot)
    {
        _chatbotRepository.UpdateChatbot(chatbot);
    }
    public async Task DeleteChatbotAsync(Chatbot chatbot)
    {
        await _chatbotRepository.DeleteChatbotAsync(chatbot);
    }

}
