using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests.UserRequests;

public class UserResetPasswordRequest
{
    [Required(ErrorMessage = "UserName là bắt buộc.")]
    [MaxLength(50, ErrorMessage = "UserName không được quá 50 ký tự.")]
    public string UserName { get; set; } = null!;
}
