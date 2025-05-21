using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Models;

public partial class Chatbot
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    [InverseProperty("Chatbot")]
    public virtual ICollection<ChatbotKeyword> ChatbotKeywords { get; set; } = new List<ChatbotKeyword>();

    [ForeignKey("UserId")]
    [InverseProperty("Chatbots")]
    public virtual User User { get; set; } = null!;
}
