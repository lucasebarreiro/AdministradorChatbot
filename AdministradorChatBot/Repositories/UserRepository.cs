using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Repositories;

public class UserRepository(ChatbotDbContext _context) : IUserRepository
{
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
