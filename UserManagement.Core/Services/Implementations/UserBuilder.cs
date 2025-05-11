using UserManagement.Core.Providers.Interfaces;
using UserManagement.Core.Requests;
using UserManagement.Core.Services.Interfaces;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Core.Services.Implementations;

public class UserBuilder(
    IDateTimeProvider dateTimeProvider,
    IRandomBytesProvider randomBytesProvider,
    IPasswordHasher passwordHasher) : IUserBuilder
{
    public User BuildUser(UserInput userInput)
    {
        byte[] userSalt = randomBytesProvider.GetRandomBytes();
        string userPlainPassword = userInput.Password;

        User user = new();

        user.Username = userInput.Username;
        user.Salt = userSalt;
        user.CreatedAt = dateTimeProvider.Now;
        user.Password = passwordHasher.HashPassword(userSalt, userPlainPassword);
        user.Role = Constants.DefaultUserRole;

        return user;
    }
}