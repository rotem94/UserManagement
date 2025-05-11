using Microsoft.IdentityModel.Tokens;
using UserManagement.Core.Interfaces.Services;

namespace UserManagement.Core.Services;

public class SigningCredentialsCreator : ISigningCredentialsCreator
{
    public SigningCredentials CreateSigningCredentials(string secretKey)
    {
        byte[] secretKeyEncoded = Convert.FromBase64String(secretKey);
        SymmetricSecurityKey securityKey = new(secretKeyEncoded);

        const string algorithm = SecurityAlgorithms.HmacSha256;

        SigningCredentials signingCredentials = new(securityKey, algorithm);

        return signingCredentials;
    }
}