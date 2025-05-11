using UserManagement.Core.Responses;

namespace UserManagement.Core.Interfaces.Services;

public interface IJwtGenerator
{
    JsonToken GenerateJwt(string username, string role = Constants.DefaultUserRole);
}