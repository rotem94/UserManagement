using UserManagement.Core;
using UserManagement.Core.Models;
using UserManagement.Core.Requests;
using UserManagement.Core.Responses;

namespace UserManagement.Core.Services.Interfaces;

public interface IUserService
{
    Task<Result> RegisterUserAsync(UserInput userInput);
    Task<Result<UserModel>> LoginUserAsync(UserInput userInput);
    Task<Result<Usernames>> GetAllUsernamesAsync();
    Task<Result> DeleteUserAsync(string username);
}