using System.Security.Claims;

namespace UserManagement.Core.Interfaces.Services;

public interface IClaimsCreator
{
    List<Claim> GenerateClaims(string username, string role);
}