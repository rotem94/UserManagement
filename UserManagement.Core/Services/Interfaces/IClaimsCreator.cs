using System.Security.Claims;

namespace UserManagement.Core.Services.Interfaces;

public interface IClaimsCreator
{
    List<Claim> GenerateClaims(string username, string role);
}