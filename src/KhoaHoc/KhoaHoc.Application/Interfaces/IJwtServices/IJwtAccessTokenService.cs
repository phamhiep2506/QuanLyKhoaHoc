using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Application.Interfaces.IJwtServices;

public interface IJwtAccessTokenService
{
    public string GenerateAccessToken(User user);
}
