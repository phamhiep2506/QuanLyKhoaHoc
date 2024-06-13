using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IJwtServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests.UserRequests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Application.Services.UserServices;

using BCrypt.Net;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _repository;
    private readonly IResponse _response;
    private readonly IJwtAccessTokenService _jwtAccessTokenService;
    private readonly IJwtRefreshTokenService _jwtRefreshTokenService;

    public UserLoginService(
        IUserRepository repository,
        IResponse response,
        IJwtAccessTokenService jwtAccessTokenService,
        IJwtRefreshTokenService jwtRefreshTokenService
    )
    {
        _repository = repository;
        _response = response;
        _jwtAccessTokenService = jwtAccessTokenService;
        _jwtRefreshTokenService = jwtRefreshTokenService;
    }

    public async Task<IResponse> LoginAsUser(UserLoginRequest userLoginRequest)
    {
        User? user = await _repository
            .Query(x => x.UserName == userLoginRequest.UserName)
            .Include(x => x.Permissions!)
            .ThenInclude(x => x.Role)
            .SingleOrDefaultAsync();

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

        string accessToken = _jwtAccessTokenService.GenerateAccessToken(user);
        string refreshToken = _jwtRefreshTokenService.GenerateRefreshToken();

        await _jwtRefreshTokenService.LoginCreateRefreshToken(
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
