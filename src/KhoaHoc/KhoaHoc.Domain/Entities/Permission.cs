using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Permission : BaseEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public Role? Role { get; set; }
    public User? User { get; set; }
}
