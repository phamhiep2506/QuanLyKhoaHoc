using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KhoaHoc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRegisterService _service;

    public UserController(IUserRegisterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> UserRegister(
        UserRegisterRequest userRegisterRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(await _service.CreateUserRegister(userRegisterRequest));
    }
}
