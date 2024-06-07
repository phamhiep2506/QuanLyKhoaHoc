using KhoaHoc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KhoaHoc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> UserRegister()
    {
        return Ok(await _service.GetAllUser());
    }
}
