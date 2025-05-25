using AdministradorChatBot.Models;

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
