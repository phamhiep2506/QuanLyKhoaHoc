namespace KhoaHoc.Application.Interfaces.IJwtServices;

public interface IJwtGetClaimsService
{
    public int GetUserId(string accessToken);
}
