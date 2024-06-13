using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task CreateRole(string roleCode, string roleName)
    {
        Role role = new Role();
        role.RoleCode = roleCode;
        role.RoleName = roleName;

        try
        {
            await AddAsync(role);
        }
        catch
        {
            throw;
        }
    }

    public async Task<int> FindRoleByName(string roleName)
    {
        Role? role = await FindAsync(x => x.RoleName == roleName);

        if (role == null)
        {
            return -1;
        }

        return role.Id;
    }
}
