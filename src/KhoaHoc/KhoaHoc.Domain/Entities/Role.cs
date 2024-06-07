using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Role : BaseEntity
{
    public string RoleCode { get; set; } = null!;
    public string RoleName { get; set; } = null!;

    public Permission? Permission { get; set; }
}
