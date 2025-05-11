using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserManagement.Core.Interfaces.Providers;
using UserManagement.Core.Interfaces.Services;

namespace UserManagement.Core.Services;

public class ClaimsCreator(IGuidProvider guidProvider) : IClaimsCreator
{
    public List<Claim> GenerateClaims(string username, string role)
    {
        string claimId = guidProvider.NewId.ToString();

        Claim subClaim = new(JwtRegisteredClaimNames.Sub, username);
        Claim roleClaim = new(ClaimTypes.Role, role);
        Claim jtiClaim = new(JwtRegisteredClaimNames.Jti, claimId);

        return [subClaim, roleClaim, jtiClaim];
    }
}