using KhoaHoc.Application.Payloads.Requests.UserRequests;

namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserLoginService
{
    public Task<IResponse> LoginAsUser(UserLoginRequest userLoginRequest);
}
