using System.ComponentModel.DataAnnotations;

namespace AdministradorChatBot.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? NombreUsuario { get; set; }

        [Required]
        public string? Contraseña { get; set; }

        public ICollection<Chatbot> Chatbots { get; set; } = [];
    }
}
