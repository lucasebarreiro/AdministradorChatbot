using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorChatBot.Models;

public partial class ChatbotResponse
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    [Required]
    public string Response { get; set; } = null!;

    public int KeywordId { get; set; }

    [ForeignKey("KeywordId")]
    [InverseProperty("ChatbotResponses")]
    public virtual ChatbotKeyword? Keyword { get; set; }
}
