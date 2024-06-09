using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests.UserRequests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

using System.IdentityModel.Tokens.Jwt;
using BCrypt.Net;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _repository;
    private readonly IResponse _response;

    public UserLoginService(IUserRepository repository, IResponse response)
    {
        _repository = repository;
        _response = response;
    }

    public async Task<IResponse> LoginAsUser(UserLoginRequest userLoginRequest)
    {
        User? user = await _repository.FindUser(userLoginRequest.UserName);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                ResponseMessage.UserLoginFailed
            );
        }

        bool isUser = BCrypt.Verify(userLoginRequest.Password, user.Password);

        if (isUser == false)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                ResponseMessage.UserLoginFailed
            );
        }

        var token = new JwtSecurityToken();
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return await _response.Content(
            ResponseStatus.Success,
            ResponseMessage.UserLoginSuccess,
            new object()
        );
    }
}
