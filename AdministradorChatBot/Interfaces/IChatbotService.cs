using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces;

public interface IChatbotService
{
    Task CreateChatbot(Chatbot chatbot);
    Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId);
    Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId);

    void UpdateChatbot(Chatbot chatbot);
    Task DeleteChatbotAsync(Chatbot chatbot);

    List<ChatMessage> GetChatHistory(int chatbotId, ISession session);
    void SaveChatHistory(int chatbotId, List<ChatMessage> history, ISession session);
    string GetChatbotResponse(Chatbot chatbot, string userMessage);
}
