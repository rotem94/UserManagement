using Microsoft.IdentityModel.Tokens;

namespace UserManagement.Core.Interfaces.Services;

public interface ISigningCredentialsCreator
{
    SigningCredentials CreateSigningCredentials(string secretKey);
}