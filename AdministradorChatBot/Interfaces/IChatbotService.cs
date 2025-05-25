using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces
{
    public interface IChatbotService
    {

        Task CrearChatbotAsync(ChatbotCreateViewModel model, int userId);
    }
}
