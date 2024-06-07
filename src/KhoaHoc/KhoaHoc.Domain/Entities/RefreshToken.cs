using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = null!;
    public DateTime ExpiryTime { get; set; }
    public int UserId { get; set; }

    public ICollection<User>? Users { get; set; }
}
