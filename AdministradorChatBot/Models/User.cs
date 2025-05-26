using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorChatBot.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Chatbot> Chatbots { get; set; } = [];
}
