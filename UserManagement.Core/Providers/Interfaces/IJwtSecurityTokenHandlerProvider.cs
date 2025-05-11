using System.IdentityModel.Tokens.Jwt;

namespace UserManagement.Core.Providers.Interfaces;

public interface IJwtSecurityTokenHandlerProvider
{
    JwtSecurityTokenHandler GetJwtSecurityTokenHandler();
}