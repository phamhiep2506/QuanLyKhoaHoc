using KhoaHoc.Application.Helpers;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.EmailServices;

public class ConfirmEmailService : IConfirmEmailService
{
    private readonly IRepository<ConfirmEmail> _repository;

    public ConfirmEmailService(IRepository<ConfirmEmail> repository)
    {
        _repository = repository;
    }

    public async Task CreateConfirmEmail(int userId)
    {
        ConfirmEmail confirmEmail = new ConfirmEmail();
        confirmEmail.UserId = userId;
        confirmEmail.ConfirmCode = RandomEmailConfirmCode.RandomString(5);
        confirmEmail.ExpiryTime = DateTime.Now.AddMinutes(1);
        confirmEmail.IsConfirm = false;

        await _repository.AddAsync(confirmEmail);
    }
}
