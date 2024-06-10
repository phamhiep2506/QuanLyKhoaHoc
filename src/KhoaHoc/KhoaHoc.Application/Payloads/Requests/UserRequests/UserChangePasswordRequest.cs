using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests.UserRequests;

public class UserChangePasswordRequest
{
    [Required(ErrorMessage = "Password là bắt buộc.")]
    [MaxLength(100, ErrorMessage = "Password không được quá 100 ký tự.")]
    public string NewPassword { get; set; } = null!;
}
