using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests.UserRequests;

public class UserLoginRequest
{
    [Required(ErrorMessage = "UserName là bắt buộc.")]
    [MaxLength(50, ErrorMessage = "UserName không được quá 50 ký tự.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Password là bắt buộc.")]
    [MaxLength(100, ErrorMessage = "Password không được quá 100 ký tự.")]
    public string Password { get; set; } = null!;
}
