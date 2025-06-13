using AdministradorChatBot.Interfaces;
using AdministradorChatBot.Models;

public class AuthService(IUserRepository _userRepository) : IAuthService
{
    public async Task<User?> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
            return null;

        if (user.PasswordHash == password)
            return user;

        return null;
    }

    public async Task<User?> RegisterAsync(string username, string password)
    {
        // Validar si el usuario ya existe
        var existingUser = await _userRepository.GetUserByUsernameAsync(username);
        if (existingUser != null)
            return null;

        var user = new User
        {
            Username = username,
            PasswordHash = password
        };

        await _userRepository.AddAsync(user);
        return user;
    }
}
