using UserManagement.Core.Interfaces.Repositories;

namespace UserManagement.Core.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    Task SaveChangesAsync();
}