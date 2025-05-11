using Microsoft.Extensions.Options;
using UserManagement.Core.Models;
using UserManagement.Core.Providers.Interfaces;

namespace UserManagement.Core.Providers.Implementations;

public class JwtSettingsProvider(IOptions<JwtSettings> jwtSettingsOptions) : IJwtSettingsProvider
{
    public JwtSettings JwtSettings => jwtSettingsOptions.Value;
}