using UserManagement.Core.Entities;

namespace UserManagement.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task<List<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    void DeleteUser(User user);
}