using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Infrastructure.Repositories;

public class UserRepository<T> : IUserRepository<T>
    where T : class
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().ToListAsync();
    }
}
