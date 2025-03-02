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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudentsWithCourse()
        {
            return _context.Students.Include(s => s.Course).ToList();
        }

        public override Student? GetById(int id)
        {
            return _context.Students
                .Include(s => s.Course)
                .FirstOrDefault(s => s.Id == id);
        }

    }
}
