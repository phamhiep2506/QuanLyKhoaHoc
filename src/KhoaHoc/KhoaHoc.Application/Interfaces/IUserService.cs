using KhoaHoc.Application.Payloads.Requests;

namespace KhoaHoc.Application.Interfaces;

public interface IUserService
{
    public Task<IResponse> UserRegister(
        UserRegisterRequest userRegisterRequest
    );
}
