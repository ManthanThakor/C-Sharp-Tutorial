using System.ComponentModel.DataAnnotations;

namespace StudentCourse.Models
{
    public class Course
    {
        public int Id { get; set; }


        public string Title { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
