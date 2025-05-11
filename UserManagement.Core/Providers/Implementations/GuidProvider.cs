using UserManagement.Core.Providers.Interfaces;

namespace UserManagement.Core.Providers.Implementations;

public class GuidProvider : IGuidProvider
{
    public Guid NewId => Guid.NewGuid();
}