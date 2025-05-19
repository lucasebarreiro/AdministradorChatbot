using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces
{
    public interface IChatbotService
    {
        Task<Chatbot> GetByIdAsync(int id);
        Task CreateChatbotAsync(Chatbot chatbot);
        Task UpdateChatbotAsync(Chatbot chatbot);
        Task DeleteChatbotAsync(int id);

    }
}
