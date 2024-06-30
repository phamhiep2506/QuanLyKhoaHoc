using System.Security.Claims;
using KhoaHoc.Application.Interfaces.ICourseServices;
using KhoaHoc.Application.Payloads.Requests.TeacherRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhoaHoc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ICreateCourceService _createCourceService;

    public TeacherController(ICreateCourceService createCourceService)
    {
        _createCourceService = createCourceService;
    }

    [HttpPost]
    [Route("create-course")]
    [Authorize]
    public async Task<IActionResult> CreateCourse(
        TeacherCreateCourseRequest teacherCreateCourseRequest
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        List<Claim> roles = User
            .Claims.Where(x => x.Type == ClaimTypes.Role)
            .ToList();

        return Ok(
            await _createCourceService.TeacherCreateCourse(
                teacherCreateCourseRequest,
                userId,
                roles
            )
        );
    }
}
