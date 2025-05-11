using Microsoft.EntityFrameworkCore;
using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Repositories;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        User? user = await appDbContext.Users.FirstOrDefaultAsync(user => user.Username == username);

        return user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        List<User> users = await appDbContext.Users.ToListAsync();

        return users;
    }

    public async Task AddUserAsync(User user)
    {
        await appDbContext.Users.AddAsync(user);
    }

    public void DeleteUser(User user)
    {
        appDbContext.Users.Remove(user);
    }
}