using AdministradorChatBot.Models;

namespace AdministradorChatBot.Interfaces
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string username, string password);
        Task<User?> RegisterAsync(string username, string password);

    }
}
