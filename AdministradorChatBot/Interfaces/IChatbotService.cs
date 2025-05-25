using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces;

public interface IChatbotService
{
    Task CreateChatbot(Chatbot chatbot);
    Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId);
    Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId);
}
