using UserManagement.Core;
using UserManagement.Core.Responses;

namespace UserManagement.Core.Services.Interfaces;

public interface IJwtGenerator
{
    JsonToken GenerateJwt(string username, string role = Constants.DefaultUserRole);
}