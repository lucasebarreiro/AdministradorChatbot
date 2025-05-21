using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

namespace AdministradorChatBot.Services;

public class AuthService(IUserRepository _userRepository) : IAuthService
{
    public async Task<User?> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user.PasswordHash == password && user.Username == username)
        {
            return user;
        }
        return null;
    }
    public async Task<User?> RegisterAsync(string username, string password)
    {
        var user = new User
        {
            Username = username,
            PasswordHash = password
        };

        await _userRepository.AddAsync(user);
        return user;
    }

}
