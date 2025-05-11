namespace UserManagement.Core.Interfaces.Providers;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}