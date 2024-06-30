using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context)
        : base(context) { }
}
