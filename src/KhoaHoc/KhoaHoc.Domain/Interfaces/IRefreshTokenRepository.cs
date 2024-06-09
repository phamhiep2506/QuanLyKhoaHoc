using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Domain.Interfaces;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    public Task AddNewRefreshToken(
        string token,
        DateTime expiryTime,
        int userId
    );
}
