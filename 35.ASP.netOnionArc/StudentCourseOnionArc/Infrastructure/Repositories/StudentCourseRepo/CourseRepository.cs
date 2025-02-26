using Domain.Entities;
using Infrastructure.EfData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.StudentCourseRepo
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetCoursesWithStudents()
        {
            return _context.Courses.Include(c => c.Students).ToList();
        }

        public override Course? GetById(int id)
        {
            return _context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == id);
        }

    }
}
