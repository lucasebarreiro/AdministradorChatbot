using System.Text.Json;
using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

namespace AdministradorChatBot.Services;

public class ChatbotService(IChatbotRepository _chatbotRepository) : IChatbotService
{
    private const string ChatHistorySessionKey = "ChatHistory_";

    public List<ChatMessage> GetChatHistory(int chatbotId, ISession session)
    {
        var key = ChatHistorySessionKey + chatbotId;
        var json = session.GetString(key);
        return json != null
            ? JsonSerializer.Deserialize<List<ChatMessage>>(json) ?? new List<ChatMessage>()
            : new List<ChatMessage>();
    }

    public void SaveChatHistory(int chatbotId, List<ChatMessage> history, ISession session)
    {
        var key = ChatHistorySessionKey + chatbotId;
        var json = JsonSerializer.Serialize(history);
        session.SetString(key, json);
    }

    private string Normalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Quita signos de puntuación y espacios, y pasa a minúsculas
        var normalized = new string(input
            .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
            .ToArray())
            .ToLower()
            .Trim();

        return normalized;
    }

    public string GetChatbotResponse(Chatbot chatbot, string userMessage)
    {
        var normalizedUserMessage = Normalize(userMessage);

        var keyword = chatbot?.ChatbotKeywords
            .FirstOrDefault(k => normalizedUserMessage.Contains(Normalize(k.Keyword)));

        if (keyword != null && keyword.ChatbotResponses.Any())
        {
            var random = new Random();
            var responses = keyword.ChatbotResponses;
            var randomResponse = responses[random.Next(responses.Count)];
            return randomResponse.Response;
        }
        return "No tengo una respuesta para eso.";
    }


    public async Task CreateChatbot(Chatbot chatbot)
    {
        await _chatbotRepository.CreateChatbotAsync(chatbot);
    }

    public Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId)
    {
        return _chatbotRepository.GetChatbotsByUserIdAsync(userId);
    }

    public Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId)
    {
        return _chatbotRepository.GetChatbotWithKeywordsAndResponsesAsync(chatbotId);
    }

    public void UpdateChatbot(Chatbot chatbot)
    {
        _chatbotRepository.UpdateChatbot(chatbot);
    }
    public async Task DeleteChatbotAsync(Chatbot chatbot)
    {
        await _chatbotRepository.DeleteChatbotAsync(chatbot);
    }

}
