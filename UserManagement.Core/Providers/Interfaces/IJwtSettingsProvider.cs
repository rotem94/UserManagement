using UserManagement.Core.Models;

namespace UserManagement.Core.Providers.Interfaces;

public interface IJwtSettingsProvider
{
    public JwtSettings JwtSettings { get; }
}