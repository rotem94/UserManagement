namespace UserManagement.Core.Interfaces.Providers;

public interface IGuidProvider
{
    Guid NewId { get; }
}