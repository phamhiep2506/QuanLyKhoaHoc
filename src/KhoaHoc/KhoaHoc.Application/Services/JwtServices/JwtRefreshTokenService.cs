using System.Security.Cryptography;
using KhoaHoc.Application.Interfaces.IJwtServices;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.JwtServices;

public class JwtRefreshTokenService : IJwtRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public JwtRefreshTokenService(
        IRefreshTokenRepository refreshTokenRepository
    )
    {
        _refreshTokenRepository = refreshTokenRepository;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
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
