using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByIdAsync(int id);

        Task AddUsuarioAsync(Usuario usuario);

        Task DeleteUsuarioAsync(int id);
    }
}
