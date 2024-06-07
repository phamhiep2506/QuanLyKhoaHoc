namespace KhoaHoc.Domain.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
}
