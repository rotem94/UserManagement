using Microsoft.IdentityModel.Tokens;

namespace UserManagement.Core.Services.Interfaces;

public interface ISigningCredentialsCreator
{
    SigningCredentials CreateSigningCredentials(string secretKey);
}