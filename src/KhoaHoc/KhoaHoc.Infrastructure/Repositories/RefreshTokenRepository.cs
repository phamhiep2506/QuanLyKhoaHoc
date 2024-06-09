using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class RefreshTokenRepository
    : Repository<RefreshToken>,
        IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task AddNewRefreshToken(
        string token,
        DateTime expiryTime,
        int userId
    )
    {
        RefreshToken refreshToken = new RefreshToken()
        {
            Token = token,
            ExpiryTime = expiryTime,
            UserId = userId
        };

        try
        {
            await AddAsync(refreshToken);
        }
        catch
        {
            throw;
        }
    }
}
