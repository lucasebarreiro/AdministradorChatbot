using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetByIdAsync(int id);
        Task CreateUserAsync(Usuario usuario);
    }
}
