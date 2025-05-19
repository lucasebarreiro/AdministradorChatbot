using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces
{
    public interface IChatbotRepository
    {
        Task<Chatbot> GetByIdAsync(int id);
        Task CreateChatbotAsync(Chatbot chatbot);
        Task UpdateChatbotAsync(Chatbot chatbot);
        Task DeleteChatbotAsync(int id);

    }
}
