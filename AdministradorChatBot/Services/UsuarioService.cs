using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

namespace AdministradorChatBot.Services
{
    public class UsuarioService(IUsuarioRepository _usuarioRepository) : IUsuarioService
    {
        public async Task CreateUserAsync(Usuario usuario)
        {
            await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

    }
}
