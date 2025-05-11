namespace UserManagement.Core.Providers.Interfaces;

public interface IGuidProvider
{
    Guid NewId { get; }
}