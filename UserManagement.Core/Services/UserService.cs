using System.Security.Cryptography;
using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Interfaces.Mappers;
using UserManagement.Core.Interfaces.Services;
using UserManagement.Core.Models;
using UserManagement.Core.Requests;
using UserManagement.Core.Responses;

namespace UserManagement.Core.Services;

public class UserService(
    IUnitOfWork unitOfWork,
    IUserBuilder userBuilder,
    IPasswordHasher passwordHasher,
    IUserMapper userMapper) : IUserService
{
    public async Task<Result> RegisterUserAsync(UserInput userInput)
    {
        User? existingUser = await unitOfWork.Users.GetUserByUsernameAsync(userInput.Username);

        if (existingUser != null)
        {
            return Result.Conflict("User already exists");
        }

        User registeredUser = userBuilder.BuildUser(userInput);

        await unitOfWork.Users.AddUserAsync(registeredUser);
        await unitOfWork.SaveChangesAsync();

        return Result.Created();
    }

    public async Task<Result<UserModel>> LoginUserAsync(UserInput userInput)
    {
        User? matchingUser = await unitOfWork.Users.GetUserByUsernameAsync(userInput.Username);

        if (matchingUser == null)
        {
            return Result<UserModel>.Unauthorized("Invalid username or password");
        }

        string inputPlainPassword = userInput.Password;

        byte[] userSalt = matchingUser.Salt;
        byte[] matchingUserHashedPassword = matchingUser.Password;

        byte[] hashedPassword = passwordHasher.HashPassword(userSalt, inputPlainPassword);

        bool doPasswordsMatch =
            CryptographicOperations.FixedTimeEquals(hashedPassword, matchingUserHashedPassword);

        if (!doPasswordsMatch)
        {
            return Result<UserModel>.Unauthorized("Invalid username or password");
        }

        UserModel user = userMapper.MapUserToUserModel(matchingUser);

        return Result<UserModel>.Success(user);
    }

    public async Task<Result<Usernames>> GetAllUsernamesAsync()
    {
        List<User> users = await unitOfWork.Users.GetAllUsersAsync();
        List<UserModel> usersModels = userMapper.MapUserCollectionToUserModelCollection(users);

        Usernames usernames = new();
        usernames.Users = usersModels;

        return Result<Usernames>.Success(usernames);
    }

    public async Task<Result> DeleteUserAsync(string username)
    {
        User? user = await unitOfWork.Users.GetUserByUsernameAsync(username);

        if (user == null)
        {
            return Result.NotFound("User wasn't found");
        }

        unitOfWork.Users.DeleteUser(user);
        await unitOfWork.SaveChangesAsync();

        return Result.NoContent();
    }
}