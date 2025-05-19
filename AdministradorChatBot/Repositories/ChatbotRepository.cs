using AdministradorChatBot.Data;
using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

namespace AdministradorChatBot.Repositories
{
    public class ChatbotRepository(AppDbContext _context) : IChatbotRepository
    {
        public async Task<Chatbot> GetByIdAsync(int id)
        {
            return await _context.Chatbots.FindAsync(id);
        }

        public async Task CreateChatbotAsync(Chatbot chatbot)
        {
            await _context.Chatbots.AddAsync(chatbot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChatbotAsync(Chatbot chatbot)
        {
            _context.Chatbots.Update(chatbot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChatbotAsync(int id)
        {
            var chatbot = await GetByIdAsync(id);
            if (chatbot != null)
            {
                _context.Chatbots.Remove(chatbot);
                await _context.SaveChangesAsync();
            }
        }
    }
}

