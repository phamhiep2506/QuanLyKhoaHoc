using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class PermissionRepository
    : Repository<Permission>,
        IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task CreatePermission(int userId, int roleId)
    {
        Permission permission = new Permission();
        permission.UserId = userId;
        permission.RoleId = roleId;

        try
        {
            await AddAsync(permission);
        }
        catch
        {
            throw;
        }
    }
}
