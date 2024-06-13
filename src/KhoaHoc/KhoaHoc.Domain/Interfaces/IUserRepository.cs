using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public Task CreateUser(User user);

    public Task<User?> FindUser(string userName);

    public Task<User?> FindUser(int userId);

    public Task UpdateUser(User user);
}
