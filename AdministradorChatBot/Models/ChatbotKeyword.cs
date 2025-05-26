using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public virtual Chatbot? Chatbot { get; set; }

    [InverseProperty("Keyword")]
    public virtual List<ChatbotResponse> ChatbotResponses { get; set; } = [];
}
