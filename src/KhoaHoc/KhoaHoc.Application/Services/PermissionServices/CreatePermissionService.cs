using KhoaHoc.Application.Interfaces.IPermissionServices;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.PermissionServices;

public class CreatePermissionService : ICreatePermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IRoleRepository _roleRepository;

    public CreatePermissionService(
        IPermissionRepository permissionRepository,
        IRoleRepository roleRepository
    )
    {
        _permissionRepository = permissionRepository;
        _roleRepository = roleRepository;
    }

    public async Task<bool> NewDefaultPermission(int userId)
    {
        try
        {
            int roleId = await _roleRepository.FindRoleByName("student");

            if (roleId == -1)
            {
                return false;
            }

            await _permissionRepository.CreatePermission(userId, roleId);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
