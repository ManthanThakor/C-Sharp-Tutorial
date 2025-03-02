using Domain.Entities;

namespace Application.Services.ServiceInterface
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course? GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
