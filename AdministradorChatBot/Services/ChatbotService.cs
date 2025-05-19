using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

namespace AdministradorChatBot.Services
{
    public class ChatbotService(IChatbotRepository _chatbotRepository) : IChatbotService
    {

        public async Task<Chatbot> GetByIdAsync(int id)
        {
            return await _chatbotRepository.GetByIdAsync(id);
        }

        public async Task CreateChatbotAsync(Chatbot chatbot)
        {
            await _chatbotRepository.CreateChatbotAsync(chatbot);
        }

        public async Task UpdateChatbotAsync(Chatbot chatbot)
        {
            await _chatbotRepository.UpdateChatbotAsync(chatbot);
        }

        public async Task DeleteChatbotAsync(int id)
        {
            await _chatbotRepository.DeleteChatbotAsync(id);
        }
    }
}
