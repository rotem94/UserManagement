using UserManagement.Core.Interfaces.Providers;

namespace UserManagement.Core.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}