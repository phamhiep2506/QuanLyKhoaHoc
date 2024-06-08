using System.Linq.Expressions;

namespace KhoaHoc.Domain.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> Query(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
    Task<T?> FindByIdAsync(int id);
    Task<T?> FindAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}
