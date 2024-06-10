using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task CreateUser(User user)
    {
        try
        {
            await AddAsync(user);
        }
        catch
        {
            throw;
        }
    }

    public async Task<User?> FindUser(string userName)
    {
        try
        {
            return await FindAsync(x => x.UserName == userName);
        }
        catch
        {
            throw;
        }
    }

    public async Task<User?> FindUser(int userId)
    {
        try
        {
            return await FindAsync(x => x.Id == userId);
        }
        catch
        {
            throw;
        }
    }
}
