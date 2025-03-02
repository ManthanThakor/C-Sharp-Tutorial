using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.StudentCourseRepo
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentsWithCourse();
    }
}
