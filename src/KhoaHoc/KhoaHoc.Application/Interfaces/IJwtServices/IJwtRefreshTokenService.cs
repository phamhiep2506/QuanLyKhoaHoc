namespace KhoaHoc.Application.Interfaces.IJwtServices;

public interface IJwtRefreshTokenService
{
    public string GenerateRefreshToken();

    public Task LoginCreateRefreshToken(string token, int userId);
}
