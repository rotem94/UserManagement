using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserManagement.Core.Mappers.Interfaces;
using UserManagement.Core.Models;
using UserManagement.Core.Providers.Interfaces;
using UserManagement.Core.Responses;
using UserManagement.Core.Services.Interfaces;

namespace UserManagement.Core.Services.Implementations;

public class JwtGenerator(
    IJwtSettingsProvider jwtSettingsProvider,
    IClaimsCreator claimsCreator,
    IDateTimeProvider dateTimeProvider,
    ISigningCredentialsCreator signingCredentialsCreator,
    IJwtSecurityTokenHandlerProvider jwtSecurityTokenHandlerProvider,
    IJsonTokenMapper jsonTokenMapper) : IJwtGenerator
{
    public JsonToken GenerateJwt(string username, string role = Constants.DefaultUserRole)
    {
        JwtSettings jwtSettings = jwtSettingsProvider.JwtSettings;
        string secretKey = jwtSettings.SecretKey;

        string issuer = jwtSettings.Issuer;
        string audience = jwtSettings.Audience;
        List<Claim> claims = claimsCreator.GenerateClaims(username, role);
        DateTime notBefore = dateTimeProvider.Now;
        DateTime expires = notBefore.AddMinutes(jwtSettings.ExpirationMinutes);
        SigningCredentials signingCredentials = signingCredentialsCreator.CreateSigningCredentials(secretKey);

        JwtSecurityToken jwtSecurityToken = new(issuer, audience, claims, notBefore, expires, signingCredentials);

        JwtSecurityTokenHandler handler = jwtSecurityTokenHandlerProvider.GetJwtSecurityTokenHandler();
        string jwtString = handler.WriteToken(jwtSecurityToken);

        JsonToken jsonToken = jsonTokenMapper.MapStringToJsonToken(jwtString);

        return jsonToken;
    }
}