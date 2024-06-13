namespace KhoaHoc.Application.Interfaces.IPermissionServices;

public interface ICreatePermissionService
{
    public Task<bool> NewDefaultPermission(int userId);
}
