using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KhoaHoc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRegisterService _userRegisterService;
    private readonly IConfirmEmailService _confirmEmailService;

    public UserController(
        IUserRegisterService userRegisterService,
        IConfirmEmailService confirmEmailService
    )
    {
        _userRegisterService = userRegisterService;
        _confirmEmailService = confirmEmailService;
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
}
