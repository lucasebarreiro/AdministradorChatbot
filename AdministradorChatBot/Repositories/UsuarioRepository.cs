using AdministradorChatBot.Data;
using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Repositories
{
    public class UsuarioRepository(AppDbContext _context) : IUsuarioRepository
    {
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _context.Usuarios
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

    }
}
