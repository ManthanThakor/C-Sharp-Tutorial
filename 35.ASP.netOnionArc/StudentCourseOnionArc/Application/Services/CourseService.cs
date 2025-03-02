using Domain.Entities;
using Infrastructure.Repositories.StudentCourseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ServiceInterface
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetCoursesWithStudents();
        }

        public Course? GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void DeleteCourse(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course != null)
            {
                _courseRepository.Delete(course);
            }
        }
    }
}
