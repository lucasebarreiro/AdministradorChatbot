using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task AddAsync(User user);
}
