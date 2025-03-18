using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class UserRepository(AppContex contex) : IUserRepository
{
    public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
       await contex.Users.AddAsync(user, cancellationToken);
       await contex.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await contex.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        contex.Users.Update(user);
        await contex.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        contex.Users.Remove(user);
        await contex.SaveChangesAsync(cancellationToken);
    }
}