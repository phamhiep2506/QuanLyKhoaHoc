using KhoaHoc.Application.Payloads.Requests;

namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserRegisterService
{
    public Task<IResponse> CreateUserRegister(
        UserRegisterRequest userRegisterRequest
    );
}
