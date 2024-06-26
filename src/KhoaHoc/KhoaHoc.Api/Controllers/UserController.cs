using System.Security.Claims;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests;
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
    private readonly IUserUpdateService _userUpdateService;
    private readonly IUserGetService _userGetService;
    private readonly IUserRefreshTokenService _userRefreshTokenService;

    public UserController(
        IUserRegisterService userRegisterService,
        IConfirmEmailService confirmEmailService,
        IUserLoginService userLoginService,
        IUserPasswordService userPasswordService,
        IUserUpdateService userUpdateService,
        IUserGetService userGetService,
        IUserRefreshTokenService userRefreshTokenService
    )
    {
        _userRegisterService = userRegisterService;
        _confirmEmailService = confirmEmailService;
        _userLoginService = userLoginService;
        _userPasswordService = userPasswordService;
        _userUpdateService = userUpdateService;
        _userGetService = userGetService;
        _userRefreshTokenService = userRefreshTokenService;
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
    [Route("change-password")]
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
    [Route("reset-password")]
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
    [Route("confirm-reset-password")]
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

    [HttpPatch]
    [Route("update")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(
        UserUpdateRequest userUpdateRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        return Ok(
            await _userUpdateService.UpdateInfo(userId, userUpdateRequest)
        );
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return Ok(await _userGetService.GetInfo(userId));
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken(
        UserRefreshTokenRequest userRefreshTokenRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(
            await _userRefreshTokenService.GenerateAccessTokenUseRefreshToken(
                userRefreshTokenRequest.userId,
                userRefreshTokenRequest.RefreshToken
            )
        );
    }
}
