using System.Security.Cryptography;
using KhoaHoc.Application.Interfaces.IJwtServices;
using KhoaHoc.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace KhoaHoc.Application.Services.JwtServices;

public class JwtRefreshTokenService : IJwtRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IConfiguration _configuration;

    public JwtRefreshTokenService(
        IRefreshTokenRepository refreshTokenRepository,
        IConfiguration configuration
    )
    {
        _refreshTokenRepository = refreshTokenRepository;
        _configuration = configuration;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task LoginCreateRefreshToken(string token, int userId)
    {
        await _refreshTokenRepository.AddNewRefreshToken(
            token,
            DateTime.Now.AddDays(
                Int32.Parse(_configuration["Jwt:RefreshTokenValidityDay"]!)
            ),
            userId
        );
    }
}
