namespace KhoaHoc.Application.Interfaces.ICreateRefreshTokenServices;

public interface ICreateRefreshTokenService
{
    public Task LoginCreateRefreshToken(
        string token,
        DateTime expiryTime,
        int userId
    );
}
