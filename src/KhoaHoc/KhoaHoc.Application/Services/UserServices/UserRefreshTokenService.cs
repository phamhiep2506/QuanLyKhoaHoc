using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IJwtServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

public class UserRefreshTokenService : IUserRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IResponse _response;
    private readonly IJwtAccessTokenService _jwtAccessTokenService;
    private readonly IJwtRefreshTokenService _jwtRefreshTokenService;

    public UserRefreshTokenService(
        IRefreshTokenRepository refreshTokenRepository,
        IJwtAccessTokenService jwtAccessTokenService,
        IResponse response,
        IUserRepository userRepository,
        IJwtRefreshTokenService jwtRefreshTokenService
    )
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtAccessTokenService = jwtAccessTokenService;
        _response = response;
        _userRepository = userRepository;
        _jwtRefreshTokenService = jwtRefreshTokenService;
    }

    public async Task<IResponse> GenerateAccessTokenUseRefreshToken(
        int userId,
        string refreshToken
    )
    {
        bool isRefreshToken = await _refreshTokenRepository.CheckRefreshToken(
            refreshToken
        );

        if (isRefreshToken == false)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                ResponseMessage.UserLoginFailed
            );
        }

        User? user = await _userRepository.FindByIdAsync(userId);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                ResponseMessage.UserLoginFailed
            );
        }

        string generateRefreshToken =
            _jwtRefreshTokenService.GenerateRefreshToken();

        await _jwtRefreshTokenService.LoginCreateRefreshToken(
            generateRefreshToken,
            user.Id
        );

        return await _response.Content(
            ResponseStatus.Success,
            ResponseMessage.UserLoginSuccess,
            new
            {
                AccessToken = _jwtAccessTokenService.GenerateAccessToken(user),
                RefreshToken = generateRefreshToken
            }
        );
    }
}
