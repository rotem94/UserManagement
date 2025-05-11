using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Mappers;
using UserManagement.Core.Models;

namespace UserManagement.Core.Mappers;

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