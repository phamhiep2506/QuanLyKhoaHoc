using KhoaHoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Infrastructure.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<ConfirmEmail> ConfirmEmails { get; set; }
    public DbSet<CertificateType> CertificateTypes { get; set; }
    public DbSet<Certificate> Certificates { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
