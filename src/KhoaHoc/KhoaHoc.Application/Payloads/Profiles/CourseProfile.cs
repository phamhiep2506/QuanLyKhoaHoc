using AutoMapper;
using KhoaHoc.Application.Payloads.Requests.TeacherRequests;
using KhoaHoc.Application.Payloads.Responses.UserResponses;
using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Application.Payloads.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<TeacherCreateCourseRequest, Course>();
    }
}
