using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task CreateUser(User user);

    Task<User?> FindUser(string userName);
}
