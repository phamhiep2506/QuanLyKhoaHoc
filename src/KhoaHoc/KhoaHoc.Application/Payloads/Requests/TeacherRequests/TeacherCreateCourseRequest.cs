namespace KhoaHoc.Application.Payloads.Requests.TeacherRequests;

public class TeacherCreateCourseRequest
{
    public string Name { get; set; } = null!;
    public string? Introduce { get; set; }
    public decimal? Price { get; set; }
}
