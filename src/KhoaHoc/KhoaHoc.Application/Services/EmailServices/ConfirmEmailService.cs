using KhoaHoc.Application.Helpers;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.EmailServices;

public class ConfirmEmailService : IConfirmEmailService
{
    private readonly IConfirmEmailRepository _repository;
    private readonly IResponse _response;

    public ConfirmEmailService(
        IConfirmEmailRepository repository,
        IResponse response
    )
    {
        _repository = repository;
        _response = response;
    }

    public async Task<string> CreateConfirmEmail(int userId)
    {
        string confirmCode = RandomEmailConfirmCode.RandomCode(5);

        ConfirmEmail confirmEmail = new ConfirmEmail();
        confirmEmail.UserId = userId;
        confirmEmail.ConfirmCode = confirmCode;
        confirmEmail.ExpiryTime = DateTime.Now.AddMinutes(3);
        confirmEmail.IsConfirm = false;

        await _repository.AddAsync(confirmEmail);

        return confirmCode;
    }

    public async Task<IResponse> UserConfirmEmailUseCode(
        int userId,
        string confirmCode
    )
    {
        bool isConfirm = await _repository.ConfirmEmailUseCode(
            userId,
            confirmCode
        );

        if (isConfirm == false)
        {
            return await _response.NoContent(
                ResponseStatus.NotAcceptable,
                ResponseMessage.ConfirmEmailFailed
            );
        }

        return await _response.NoContent(
            ResponseStatus.Success,
            ResponseMessage.ConfirmEmailSuccess
        );
    }
}
