using UserManagement.Core.Requests;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Core.Services.Interfaces;

public interface IUserBuilder
{
    User BuildUser(UserInput userInput);
}