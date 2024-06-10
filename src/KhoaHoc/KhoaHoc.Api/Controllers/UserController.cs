using System.Security.Claims;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests.UserRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhoaHoc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRegisterService _userRegisterService;
    private readonly IConfirmEmailService _confirmEmailService;
    private readonly IUserLoginService _userLoginService;
    private readonly IUserPasswordService _userPasswordService;

    public UserController(
        IUserRegisterService userRegisterService,
        IConfirmEmailService confirmEmailService,
        IUserLoginService userLoginService,
        IUserPasswordService userPasswordService
    )
    {
        _userRegisterService = userRegisterService;
        _confirmEmailService = confirmEmailService;
        _userLoginService = userLoginService;
        _userPasswordService = userPasswordService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> UserRegister(
        UserRegisterRequest userRegisterRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(
            await _userRegisterService.CreateUserRegister(userRegisterRequest)
        );
    }

    [HttpPost]
    [Route("confirm")]
    public async Task<IActionResult> UserConfirmEmail(
        UserConfirmEmailRequest userConfirmEmailRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(
            await _confirmEmailService.UserConfirmEmailUseCode(
                userConfirmEmailRequest.UserId,
                userConfirmEmailRequest.ConfirmCode
            )
        );
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> UserLogin(
        UserLoginRequest userLoginRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(await _userLoginService.LoginAsUser(userLoginRequest));
    }

    [HttpPost]
    [Route("cpass")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(
        UserChangePasswordRequest userChangePasswordRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        return Ok(
            await _userPasswordService.ChangePassword(
                userId,
                userChangePasswordRequest.NewPassword
            )
        );
    }

    [HttpPost]
    [Route("rpass")]
    public async Task<IActionResult> ResetPassword(
        UserResetPasswordRequest userResetPasswordRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(
            await _userPasswordService.ResetPassword(
                userResetPasswordRequest.UserName
            )
        );
    }

    [HttpPost]
    [Route("crpass")]
    public async Task<IActionResult> ConfirmResetPassword(
        UserConfirmResetPasswordRequest userConfirmResetPasswordRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(
            await _userPasswordService.ConfirmResetPassword(
                userConfirmResetPasswordRequest.UserName,
                userConfirmResetPasswordRequest.ConfirmCode,
                userConfirmResetPasswordRequest.NewPassword
            )
        );
    }
}
