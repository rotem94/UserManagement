using UserManagement.Infrastructure.Models;

namespace UserManagement.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task<List<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    void DeleteUser(User user);
}