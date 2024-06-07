using KhoaHoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Infrastructure.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<RefreshToken> RefreshTokens { get; set; }
    DbSet<Permission> Permissions { get; set; }
    DbSet<ConfirmEmail> ConfirmEmails { get; set; }
    DbSet<CertificateType> CertificateTypes { get; set; }
    DbSet<Certificate> Certificates { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
