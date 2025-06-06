﻿using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces;

public interface IChatbotRepository
{
    Task CreateChatbotAsync(Chatbot chatbot);
    Task<List<Chatbot>> GetChatbotsByUserIdAsync(int userId);
    Task<Chatbot?> GetChatbotWithKeywordsAndResponsesAsync(int chatbotId);

    void UpdateChatbot(Chatbot chatbot);
    Task DeleteChatbotAsync(Chatbot chatbot);
}

