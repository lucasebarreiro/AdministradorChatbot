using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Repositories;

public class ChatbotRepository(ChatbotDbContext _context) : IChatbotRepository
{
    public async Task CreateChatbotAsync(Chatbot chatbot)
    {
        _context.Chatbots.Add(chatbot);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId)
    {
        return await _context.Chatbots
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId)
    {
        return _context.Chatbots
            .Include(ck => ck.ChatbotKeywords)
            .ThenInclude(cr => cr.ChatbotResponses)
            .FirstOrDefaultAsync(c => c.Id == chatbotId);
    }
}
