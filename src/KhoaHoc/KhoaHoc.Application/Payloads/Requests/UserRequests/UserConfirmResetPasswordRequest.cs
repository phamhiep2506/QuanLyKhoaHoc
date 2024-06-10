using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests.UserRequests;

public class UserConfirmResetPasswordRequest
{
    [Required(ErrorMessage = "UserName là bắt buộc.")]
    [MaxLength(50, ErrorMessage = "UserName không được quá 50 ký tự.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "ConfirmCode là bắt buộc")]
    [MaxLength(5, ErrorMessage = "ConfirmCode chỉ có 5 ký tự.")]
    [MinLength(5, ErrorMessage = "ConfirmCode chỉ có 5 ký tự.")]
    public string ConfirmCode { get; set; } = null!;

    [Required(ErrorMessage = "Password là bắt buộc.")]
    [MaxLength(100, ErrorMessage = "Password không được quá 100 ký tự.")]
    public string NewPassword { get; set; } = null!;
}
