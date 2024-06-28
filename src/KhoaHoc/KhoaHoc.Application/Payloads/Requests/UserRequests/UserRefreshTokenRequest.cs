using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests.UserRequests;

public class UserRefreshTokenRequest
{
    [Required]
    public int userId { get; set; }

    [Required]
    public string RefreshToken { get; set; } = null!;
}
