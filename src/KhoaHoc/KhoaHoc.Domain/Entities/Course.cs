using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Course : BaseEntity
{
    public string? Name { get; set; }
    public string? Introduce { get; set; }
    public string? ImageCourse { get; set; }
    public int CreatorId { get; set; }
    public string? Code { get; set; }
    public decimal Price { get; set; }
    public int TotalCourseDuration { get; set; }
    public int NumberOfStudent { get; set; }
    public int NumberOfPurchases { get; set; }

    public ICollection<CourseSubject>? CourseSubjects { get; set; }
}
