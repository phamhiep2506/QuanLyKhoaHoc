using KhoaHoc.Application.Interfaces.IRefreshTokenServices;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.RefreshTokenServices;

public class CreateRefreshTokenService : ICreateRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public CreateRefreshTokenService(
        IRefreshTokenRepository refreshTokenRepository
    )
    {
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task LoginCreateRefreshToken(
        string token,
        DateTime expiryTime,
        int userId
    )
    {
        await _refreshTokenRepository.AddNewRefreshToken(
            token,
            expiryTime,
            userId
        );
    }
}
