using KhoaHoc.Domain.Entities;
using KhoaHoc.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Permission> Permissions { get; set; }

    public DbSet<ConfirmEmail> ConfirmEmails { get; set; }

    public DbSet<CertificateType> CertificateTypes { get; set; }

    public DbSet<Certificate> Certificates { get; set; }
}
