using Microsoft.Extensions.Options;
using UserManagement.Core.Interfaces.Providers;
using UserManagement.Core.Models;

namespace UserManagement.Core.Providers;

public class JwtSettingsProvider(IOptions<JwtSettings> jwtSettingsOptions) : IJwtSettingsProvider
{
    public JwtSettings JwtSettings => jwtSettingsOptions.Value;
}