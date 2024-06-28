using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class SubjectDetail : BaseEntity
{
    public int SubjectId { get; set; }
    public string? Name { get; set; }
    public bool IsFinished { get; set; }
    public string? LinkVideo { get; set; }
    public bool IsActive { get; set; }

    public Subject? Subject { get; set; }
}
