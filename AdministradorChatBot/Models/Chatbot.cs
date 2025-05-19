using System.ComponentModel.DataAnnotations;

namespace AdministradorChatBot.Models
{
    public class Chatbot
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public ICollection<PreguntaRespuesta> PreguntasRespuestas { get; set; } = [];
    }
}
