using System.Linq.Expressions;

namespace KhoaHoc.Domain.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}
