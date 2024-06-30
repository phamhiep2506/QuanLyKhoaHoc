using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class CertificateRepository
    : Repository<Certificate>,
        ICertificateRepository
{
    public CertificateRepository(ApplicationDbContext context)
        : base(context) { }
}
