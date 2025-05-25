using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Repositories;

public class ChatbotRepository(ChatbotDbContext _context) : IChatbotRepository
{
    public async Task AddAsync(Chatbot chatbot)
    {
        _context.Chatbots.Add(chatbot);
        await _context.SaveChangesAsync();
    }

    public async Task<Chatbot?> GetByIdAsync(int id)
    {
        return await _context.Chatbots
            .Include(c => c.ChatbotKeywords)
                .ThenInclude(k => k.ChatbotResponses)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Chatbot>> GetByUserIdAsync(int userId)
    {
        return await _context.Chatbots
            .Where(c => c.UserId == userId)
            .Include(c => c.ChatbotKeywords)
                .ThenInclude(k => k.ChatbotResponses)
            .ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var chatbot = await _context.Chatbots.FindAsync(id);
        if (chatbot != null)
        {
            _context.Chatbots.Remove(chatbot);
            await _context.SaveChangesAsync();
        }
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