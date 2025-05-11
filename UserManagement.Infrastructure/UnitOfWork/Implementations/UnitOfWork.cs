using UserManagement.Infrastructure.Models;
using UserManagement.Infrastructure.Repositories.Interfaces;
using UserManagement.Infrastructure.UnitOfWork.Interfaces;

namespace UserManagement.Infrastructure.UnitOfWork.Implementations;

public class UnitOfWork(AppDbContext appDbContext, IUserRepository userRepository) : IUnitOfWork
{
    public IUserRepository Users => userRepository;

    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}