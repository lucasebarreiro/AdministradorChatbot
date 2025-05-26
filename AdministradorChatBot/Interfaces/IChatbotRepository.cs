using AdministradorChatBot.Models;

<<<<<<< HEAD
namespace AdministradorChatBot.Interfaces
{
    public interface IChatbotRepository
    {
        Task AddAsync(Chatbot chatbot);
        Task<Chatbot?> GetByIdAsync(int id);
        Task<List<Chatbot>> GetByUserIdAsync(int userId);
        Task DeleteAsync(int id);
    }
}
=======
namespace AdministradorChatBot.Interfaces;

public interface IChatbotRepository
{
    Task CreateChatbotAsync(Chatbot chatbot);
    Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId);
    Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId);
}

>>>>>>> origin/pw3-barreiro
