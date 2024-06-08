namespace KhoaHoc.Application.Interfaces.IEmailServices;

public interface IConfirmEmailService
{
    public Task CreateConfirmEmail(int userId);

    public Task<IResponse> UserConfirmEmailUseCode(
        int userId,
        string confirmCode
    );
}
