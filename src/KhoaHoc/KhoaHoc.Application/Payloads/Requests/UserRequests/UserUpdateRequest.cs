using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Application.Payloads.Requests;

public class UserUpdateRequest
{
    [MaxLength(50, ErrorMessage = "UserName không được quá 50 ký tự.")]
    public string? UserName { get; set; }

    [MaxLength(100, ErrorMessage = "Email không được quá 100 ký tự.")]
    [EmailAddress(ErrorMessage = "Email không đúng.")]
    public string? Email { get; set; }

    [MaxLength(100, ErrorMessage = "FullName không được quá 100 ký tự.")]
    public string? FullName { get; set; }

    [MaxLength(200, ErrorMessage = "Address không được quá 200 ký tự.")]
    public string? Address { get; set; }
}
