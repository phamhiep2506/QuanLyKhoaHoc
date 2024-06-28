namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserRefreshTokenService
{
    public Task<IResponse> GenerateAccessTokenUseRefreshToken(
        int userId,
        string refreshToken
    );
}
