using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Domain.Interfaces;

public interface IPermissionRepository : IRepository<Permission>
{
    public Task CreatePermission(int userId, int roleId);
}
