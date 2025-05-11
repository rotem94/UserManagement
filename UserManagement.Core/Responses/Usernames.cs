using UserManagement.Core.Models;

namespace UserManagement.Core.Responses;

public class Usernames
{
    public List<UserModel> Users { get; set; } = [];
}