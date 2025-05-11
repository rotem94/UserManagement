using System.IdentityModel.Tokens.Jwt;

namespace UserManagement.Core.Interfaces.Providers;

public interface IJwtSecurityTokenHandlerProvider
{
    JwtSecurityTokenHandler GetJwtSecurityTokenHandler();
}