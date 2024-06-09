using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Application.Interfaces;

public interface IJsonWebToken
{
    public string GenerateAccessToken(User user);

    public string GenerateRefreshToken();
}
