using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Domain.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    public Task CreateRole(string roleCode, string roleName);

    public Task<int> FindRoleByName(string roleName);
}
