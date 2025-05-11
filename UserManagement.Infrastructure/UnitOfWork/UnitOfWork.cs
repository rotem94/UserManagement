using UserManagement.Core.Interfaces;
using UserManagement.Core.Interfaces.Repositories;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.UnitOfWork;

public class UnitOfWork(AppDbContext appDbContext, IUserRepository userRepository) : IUnitOfWork
{
    public IUserRepository Users => userRepository;

    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}