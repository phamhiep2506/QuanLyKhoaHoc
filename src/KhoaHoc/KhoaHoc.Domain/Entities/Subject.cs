using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Subject : BaseEntity
{
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public bool IsActive { get; set; }
}
