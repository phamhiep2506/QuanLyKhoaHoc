using MimeKit;

namespace KhoaHoc.Application.Interfaces.IEmailServices;

public interface ISendEmailService
{
    public MimeMessage CreateMessage(
        string toAddress,
        string subject,
        string htmlBody
    );

    public Task Send(MimeMessage message);
}
