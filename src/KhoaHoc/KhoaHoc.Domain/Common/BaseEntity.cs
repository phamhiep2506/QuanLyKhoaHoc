using System.ComponentModel.DataAnnotations;

namespace KhoaHoc.Domain.Common;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
