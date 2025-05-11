using UserManagement.Core.Models;

namespace UserManagement.Core.Interfaces.Providers;

public interface IJwtSettingsProvider
{
    public JwtSettings JwtSettings { get; }
}