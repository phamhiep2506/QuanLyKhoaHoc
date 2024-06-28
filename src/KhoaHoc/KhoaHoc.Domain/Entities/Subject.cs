using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Subject : BaseEntity
{
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public bool IsActive { get; set; }

    public ICollection<CourseSubject>? CourseSubjects { get; set; }
    public ICollection<SubjectDetail>? SubjectDetails { get; set; }
    public ICollection<RegisterStudy>? RegisterStudies { get; set; }
    public ICollection<LearningProgress>? LearningProgresses { get; set; }
}
