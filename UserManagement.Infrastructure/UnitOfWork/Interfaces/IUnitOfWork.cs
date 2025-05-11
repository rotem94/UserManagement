using UserManagement.Infrastructure.Repositories.Interfaces;

namespace UserManagement.Infrastructure.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    Task SaveChangesAsync();
}