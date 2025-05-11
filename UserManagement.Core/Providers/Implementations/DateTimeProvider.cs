using UserManagement.Core.Providers.Interfaces;

namespace UserManagement.Core.Providers.Implementations;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}