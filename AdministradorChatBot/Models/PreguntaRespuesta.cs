using System.ComponentModel.DataAnnotations;

namespace AdministradorChatBot.Models
{
    public class PreguntaRespuesta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Pregunta { get; set; }

        [Required]
        public string? Respuesta { get; set; }

        public int ChatbotId { get; set; }
        public Chatbot? Chatbot { get; set; }
    }
}
