using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Models;

public partial class ChatbotKeyword
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Keyword { get; set; } = null!;

    public int ChatbotId { get; set; }

    [ForeignKey("ChatbotId")]
    [InverseProperty("ChatbotKeywords")]
    public virtual Chatbot Chatbot { get; set; } = null!;

    [InverseProperty("Keyword")]
    public virtual ICollection<ChatbotResponse> ChatbotResponses { get; set; } = new List<ChatbotResponse>();
}
