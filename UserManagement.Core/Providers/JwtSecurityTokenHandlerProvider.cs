using System.IdentityModel.Tokens.Jwt;
using UserManagement.Core.Interfaces.Providers;

namespace UserManagement.Core.Providers;

public class JwtSecurityTokenHandlerProvider : IJwtSecurityTokenHandlerProvider
{
    public JwtSecurityTokenHandler GetJwtSecurityTokenHandler()
    {
        return new JwtSecurityTokenHandler();
    }
}