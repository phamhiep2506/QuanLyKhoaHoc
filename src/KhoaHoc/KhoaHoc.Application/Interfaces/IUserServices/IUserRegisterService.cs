using KhoaHoc.Application.Payloads.Requests.UserRequests;

namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserRegisterService
{
    public Task<IResponse> CreateUserRegister(
        UserRegisterRequest userRegisterRequest
    );
}
