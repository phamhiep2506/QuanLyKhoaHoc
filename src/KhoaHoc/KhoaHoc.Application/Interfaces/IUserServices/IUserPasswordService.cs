namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserPasswordService
{
    public Task<IResponse> ChangePassword(int userId, string newPassword);

    public Task<IResponse> ResetPassword(string userName);

    public Task<IResponse> ConfirmResetPassword(
        string userName,
        string codeResetPassword,
        string newPassword
    );
}
