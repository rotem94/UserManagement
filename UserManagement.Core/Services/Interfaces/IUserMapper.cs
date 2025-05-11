using UserManagement.Core.Models;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Core.Services.Interfaces;

public interface IUserMapper
{
    List<UserModel> MapUserCollectionToUserModelCollection(List<User> users);
    UserModel MapUserToUserModel(User user);
}