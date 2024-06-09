using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests.UserRequests;

public class UserConfirmEmailRequest
{
    [Required(ErrorMessage = "UserId là bắt buộc.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "ConfirmCode là bắt buộc")]
    [MaxLength(5, ErrorMessage = "ConfirmCode chỉ có 5 ký tự.")]
    [MinLength(5, ErrorMessage = "ConfirmCode chỉ có 5 ký tự.")]
    public string ConfirmCode { get; set; } = null!;
}
