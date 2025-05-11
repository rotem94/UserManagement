using UserManagement.Core.Models;
using UserManagement.Core.Services.Interfaces;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Core.Services.Implementations;

public class UserMapper : IUserMapper
{
    public List<UserModel> MapUserCollectionToUserModelCollection(List<User> users)
    {
        List<UserModel> usersModel = users.Select(MapUserToUserModel).ToList();

        return usersModel;
    }

    public UserModel MapUserToUserModel(User user)
    {
        UserModel userModel = new();

        userModel.Username = user.Username;
        userModel.Role = user.Role;

        return userModel;
    }
}