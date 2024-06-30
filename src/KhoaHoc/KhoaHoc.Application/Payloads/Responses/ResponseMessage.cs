namespace KhoaHoc.Application.Payloads.Responses;

public static class ResponseMessage
{
    // User
    public const string UserRegisterSuccess = "Đăng ký tài khoản thành công.";
    public const string UserRegisterFailed =
        "Đăng ký tài khoản không thành công.";
    public const string UserExisted = "Tài khoản đã tồn tại.";
    public const string UserNotExisted = "Tài khoản không tồn tại.";
    public const string UserChangePasswordSuccess =
        "Thay đổi mật khẩu thành công.";

    // Email
    public const string ConfirmEmailSuccess = "Xác nhận email thành công.";
    public const string ConfirmEmailFailed = "Xác nhận email không thành công.";

    // Login
    public const string UserLoginFailed = "Đăng nhập không thành công.";
    public const string UserLoginSuccess = "Đăng nhập thành công.";
    public const string AccountIsNotVerified = "Tài khoản chưa được xác minh.";

    // Password
    public const string CheckResetEmailPassword =
        "Mã đã được gửi, vui lòng kiểm tra email.";
    public const string ResetPasswordSuccess = "Đặt lại mật khẩu thành công.";
    public const string ResetPasswordFailed =
        "Đặt lại mật khẩu không thành công.";

    // Update
    public const string UserUpdateSuccess = "Cập nhập thông tin thành công.";

    // Get
    public const string UserGetSuccess = "Lấy thông tin thành công.";

    // Teacher create course
    public const string TeacherPermissionFailed =
        "Bạn không có quyền giảng viên";
    public const string TeacherCreateCourseSuccess = "";
}
