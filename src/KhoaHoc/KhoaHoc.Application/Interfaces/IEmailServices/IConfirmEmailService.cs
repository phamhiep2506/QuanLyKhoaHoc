namespace KhoaHoc.Application.Interfaces.IEmailServices;

public interface IConfirmEmailService
{
    public Task CreateConfirmEmail(int userId);
}
