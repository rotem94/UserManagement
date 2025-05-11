using UserManagement.Core.Interfaces.Providers;

namespace UserManagement.Core.Providers;

public class GuidProvider : IGuidProvider
{
    public Guid NewId => Guid.NewGuid();
}