using System.Security.Claims;
using KhoaHoc.Application.Payloads.Requests.TeacherRequests;

namespace KhoaHoc.Application.Interfaces.ICourseServices;

public interface ICreateCourceService
{
    public Task<IResponse> TeacherCreateCourse(
        TeacherCreateCourseRequest teacherCreateCourseRequest,
        int userId,
        List<Claim> roles
    );
}
