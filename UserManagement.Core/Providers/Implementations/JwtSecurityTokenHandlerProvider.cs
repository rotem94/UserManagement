using System.IdentityModel.Tokens.Jwt;
using UserManagement.Core.Providers.Interfaces;

namespace UserManagement.Core.Providers.Implementations;

public class JwtSecurityTokenHandlerProvider : IJwtSecurityTokenHandlerProvider
{
    public JwtSecurityTokenHandler GetJwtSecurityTokenHandler()
    {
        return new JwtSecurityTokenHandler();
    }
}