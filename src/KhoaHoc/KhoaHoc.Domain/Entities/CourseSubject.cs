using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class CourseSubject : BaseEntity
{
    public int CourseId { get; set; }
    public int SubjectId { get; set; }
}
