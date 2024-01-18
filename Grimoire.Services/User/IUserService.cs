using Grimoire.Models.User;

namespace Grimoire.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> LoginAsync(UserLogin model);
    Task LogoutAsync();
    Task<bool> AddDeityToUser(int userId, int[] selectedDeityIds);
    
}
