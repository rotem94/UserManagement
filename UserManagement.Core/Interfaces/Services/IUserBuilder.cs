using UserManagement.Core.Entities;
using UserManagement.Core.Requests;

namespace UserManagement.Core.Interfaces.Services;

public interface IUserBuilder
{
    User BuildUser(UserInput userInput);
}