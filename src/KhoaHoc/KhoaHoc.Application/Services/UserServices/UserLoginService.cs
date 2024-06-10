using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IRefreshTokenServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests.UserRequests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

using BCrypt.Net;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _repository;
    private readonly IResponse _response;
    private readonly IJsonWebToken _jsonWebToken;
    private readonly ICreateRefreshTokenService _createRefreshTokenService;

    public UserLoginService(
        IUserRepository repository,
        IResponse response,
        IJsonWebToken jsonWebToken,
        ICreateRefreshTokenService createRefreshTokenService
    )
    {
        _repository = repository;
        _response = response;
        _jsonWebToken = jsonWebToken;
        _createRefreshTokenService = createRefreshTokenService;
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

        if (user.IsActive == false)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                ResponseMessage.AccountIsNotVerified
            );
        }

        string accessToken = _jsonWebToken.GenerateAccessToken(user);
        string refreshToken = _jsonWebToken.GenerateRefreshToken();

        await _createRefreshTokenService.LoginCreateRefreshToken(
            refreshToken,
            DateTime.Now.AddDays(10),
            user.Id
        );

        return await _response.Content(
            ResponseStatus.Success,
            ResponseMessage.UserLoginSuccess,
            new { AccessToken = accessToken, RefreshToken = refreshToken }
        );
    }
}
