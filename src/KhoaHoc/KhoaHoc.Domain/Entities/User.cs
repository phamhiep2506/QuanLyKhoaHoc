using KhoaHoc.Domain.Common;
using KhoaHoc.Domain.Enums;

namespace KhoaHoc.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public DateTime CreateTime { get; set; }
    public string? Avatar { get; set; }
    public string Email { get; set; } = null!;
    public DateTime UpdateTime { get; set; }
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public string? Address { get; set; }
    public int DistrictId { get; set; }
    public int ProvinceId { get; set; }
    public int CertificateId { get; set; }
    public int WardId { get; set; }
    public UserActivationStatus UserStatus { get; set; } =
        UserActivationStatus.UnActivated;

    public Permission? Permission { get; set; }
    public ConfirmEmail? ConfirmEmail { get; set; }
    public RefreshToken? RefreshToken { get; set; }

    public ICollection<Certificate>? Certificates { get; set; }
}
