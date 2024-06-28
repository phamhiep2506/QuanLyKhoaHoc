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
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseSubject> CourseSubjects { get; set; }
    public DbSet<LearningProgress> LearningProgresses { get; set; }
    public DbSet<RegisterStudy> RegisterStudies { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<SubjectDetail> SubjectDetails { get; set; }
}
