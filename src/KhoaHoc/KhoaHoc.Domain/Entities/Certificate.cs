using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class Certificate : BaseEntity
{
    public int CertificateTypeId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Image { get; set; }

    public ICollection<CertificateType>? CertificateTypes { get; set; }
    public User? User { get; set; }
}
