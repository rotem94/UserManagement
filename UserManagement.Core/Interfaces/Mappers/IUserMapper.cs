using UserManagement.Core.Entities;
using UserManagement.Core.Models;

namespace UserManagement.Core.Interfaces.Mappers;

public interface IUserMapper
{
    List<UserModel> MapUserCollectionToUserModelCollection(List<User> users);
    UserModel MapUserToUserModel(User user);
}