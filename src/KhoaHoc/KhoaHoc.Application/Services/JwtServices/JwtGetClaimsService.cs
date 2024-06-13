using System.IdentityModel.Tokens.Jwt;
using KhoaHoc.Application.Interfaces.IJwtServices;

namespace KhoaHoc.Application.Services.JwtServices;

public class JwtGetClaimsService : IJwtGetClaimsService
{
    public int GetUserId(string accessToken)
    {
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
        return int.Parse(
            jwt.Claims.First(c => c.Type == "NameIdentifier").Value
        );
    }
}
