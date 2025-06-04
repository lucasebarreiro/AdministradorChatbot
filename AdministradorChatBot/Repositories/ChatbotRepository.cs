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

    public void UpdateChatbot(Chatbot chatbot)
    {
        var existingChatbot = _context.Chatbots
            .Include(c => c.ChatbotKeywords)
                .ThenInclude(k => k.ChatbotResponses)
            .FirstOrDefault(c => c.Id == chatbot.Id);

        if (existingChatbot == null) return;

        existingChatbot.Name = chatbot.Name;
        existingChatbot.Description = chatbot.Description;

        // eliminar las anteriores
        _context.ChatbotResponses.RemoveRange(existingChatbot.ChatbotKeywords.SelectMany(k => k.ChatbotResponses));
        _context.ChatbotKeywords.RemoveRange(existingChatbot.ChatbotKeywords);

        // Agregar las nuevas
        existingChatbot.ChatbotKeywords = chatbot.ChatbotKeywords;

        _context.SaveChanges();
    }
    public async Task DeleteChatbotAsync(Chatbot chatbot)
    {
        _context.Chatbots.Remove(chatbot);
        await _context.SaveChangesAsync();
    }
}
