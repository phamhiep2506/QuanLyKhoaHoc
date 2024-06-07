using System.Linq.Expressions;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Infrastructure.Repositories;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AnyAsync(expression);
    }
}
