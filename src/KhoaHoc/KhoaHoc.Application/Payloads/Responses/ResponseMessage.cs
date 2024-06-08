namespace KhoaHoc.Application.Payloads.Responses;

public static class ResponseMessage
{
    // User
    public const string UserRegisterSuccess = "Đăng ký tài khoản thành công.";
    public const string UserRegisterFailed =
        "Đăng ký tài khoản không thành công.";
    public const string UserRegisterExisted = "Tài khoản đã tồn tại.";

    // Email
    public const string ConfirmEmailSuccess = "Xác nhận email thành công.";
    public const string ConfirmEmailFailed = "Xác nhận email không thành công.";
}
