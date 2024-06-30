using System.Security.Claims;
using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.ICourseServices;
using KhoaHoc.Application.Payloads.Requests.TeacherRequests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Application.Services.CourseServices;

public class CreateCourceService : ICreateCourceService
{
    private readonly IResponse _response;
    private readonly IUserRepository _userRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CreateCourceService(
        IResponse response,
        IUserRepository userRepository,
        ICourseRepository courseRepository,
        IMapper mapper
    )
    {
        _response = response;
        _userRepository = userRepository;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<IResponse> TeacherCreateCourse(
        TeacherCreateCourseRequest teacherCreateCourseRequest,
        int userId,
        List<Claim> roles
    )
    {
        bool isTeacherPermission = false;

        foreach (Claim role in roles)
        {
            if(role.Value == "teacher")
            {
                isTeacherPermission = true;
            }
        }

        if (isTeacherPermission == false)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                ResponseMessage.TeacherPermissionFailed
            );
        }

        User user = await _userRepository
            .Query(x => x.Id == userId)
            .Include(x => x.Certificate)
            .SingleAsync();

        if (user.Certificate == null)
        {
            return await _response.NoContent(
                ResponseStatus.Unauthorized,
                "Bạn chưa có chứng chỉ."
            );
        }

        Course course = _mapper.Map<TeacherCreateCourseRequest, Course>(
            teacherCreateCourseRequest
        );

        await _courseRepository.AddAsync(course);

        return await _response.NoContent(
            ResponseStatus.Success,
            "Tạo khóa học thành công."
        );
    }
}
