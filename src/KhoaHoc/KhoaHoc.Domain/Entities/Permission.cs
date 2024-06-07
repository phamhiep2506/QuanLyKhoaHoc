using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Permission : BaseEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public ICollection<Role>? Roles { get; set; }
    public ICollection<User>? Users { get; set; }
}
