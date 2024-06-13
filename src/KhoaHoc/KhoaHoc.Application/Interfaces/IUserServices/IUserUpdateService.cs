using KhoaHoc.Application.Payloads.Requests;

namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserUpdateService
{
    public Task<IResponse> UpdateInfo(int userId, UserUpdateRequest userUpdateRequest);
}
