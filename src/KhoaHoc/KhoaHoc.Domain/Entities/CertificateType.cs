using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class CertificateType : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<Certificate>? Certificates { get; set; }
}
