using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorChatBot.Models;

public partial class Chatbot
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    [InverseProperty("Chatbot")]
    public virtual List<ChatbotKeyword> ChatbotKeywords { get; set; } = [];
    [ForeignKey("UserId")]
    [InverseProperty("Chatbots")]
    public virtual User? User { get; set; }
    public string Description { get; set; } = null!;
}
