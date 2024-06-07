using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class ConfirmEmail : BaseEntity
{
    public string ConfirmCode { get; set; } = null!;
    public DateTime ExpiryTime { get; set; }
    public int UserId { get; set; }
    public bool IsConfirm { get; set; }

    public ICollection<User>? Users { get; set; }
}
