using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Providers;
using UserManagement.Core.Interfaces.Services;
using UserManagement.Core.Requests;

namespace UserManagement.Core.Services;

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