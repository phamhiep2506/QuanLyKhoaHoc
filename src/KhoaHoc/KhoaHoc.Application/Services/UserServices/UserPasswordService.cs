using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

using BCrypt.Net;
using KhoaHoc.Application.Helpers;
using KhoaHoc.Application.Interfaces.IEmailServices;

public class UserPasswordService : IUserPasswordService
{
    private readonly IUserRepository _userRepository;
    private readonly IResponse _response;
    private readonly ISendEmailService _sendEmailService;
    private readonly IConfirmEmailRepository _confirmEmailRepository;

    public UserPasswordService(
        IUserRepository userRepository,
        IResponse response,
        ISendEmailService sendEmailService,
        IConfirmEmailRepository confirmEmailRepository
    )
    {
        _userRepository = userRepository;
        _response = response;
        _sendEmailService = sendEmailService;
        _confirmEmailRepository = confirmEmailRepository;
    }

    public async Task<IResponse> ChangePassword(int userId, string newPassword)
    {
        User? user = await _userRepository.FindUser(userId);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserNotExisted
            );
        }

        user.Password = BCrypt.HashPassword(newPassword);
        await _userRepository.UpdateAsync(user);

        return await _response.NoContent(
            ResponseStatus.Success,
            ResponseMessage.UserChangePasswordSuccess
        );
    }

    public async Task<IResponse> ResetPassword(string userName)
    {
        User? user = await _userRepository.FindUser(userName);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserNotExisted
            );
        }

        string code = RandomEmailConfirmCode.RandomCode(5);

        ConfirmEmail confirmEmail = new ConfirmEmail()
        {
            ConfirmCode = code,
            ExpiryTime = DateTime.Now.AddMinutes(3),
            UserId = user.Id,
            IsConfirm = false
        };
        await _confirmEmailRepository.AddAsync(confirmEmail);

        var message = _sendEmailService.CreateMessage(
            user.Email,
            "Reset password",
            $"<b>Code:</b> {code}"
        );
        await _sendEmailService.Send(message);

        return await _response.NoContent(
            ResponseStatus.Success,
            ResponseMessage.CheckResetEmailPassword
        );
    }

    public async Task<IResponse> ConfirmResetPassword(
        string userName,
        string codeResetPassword,
        string newPassword
    )
    {
        User? user = await _userRepository.FindUser(userName);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserNotExisted
            );
        }

        bool IsResetPassword =
            await _confirmEmailRepository.ConfirmEmailUseCode(
                user.Id,
                codeResetPassword
            );

        if (IsResetPassword == false)
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.ResetPasswordFailed
            );
        }

        user.Password = BCrypt.HashPassword(newPassword);
        await _userRepository.UpdateAsync(user);

        return await _response.NoContent(
            ResponseStatus.Success,
            ResponseMessage.ResetPasswordSuccess
        );
    }
}
