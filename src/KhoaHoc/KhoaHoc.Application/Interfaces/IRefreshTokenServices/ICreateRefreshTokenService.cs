namespace KhoaHoc.Application.Interfaces.IRefreshTokenServices;

public interface ICreateRefreshTokenService
{
    public Task LoginCreateRefreshToken(
        string token,
        DateTime expiryTime,
        int userId
    );
}
