using System.ComponentModel.DataAnnotations;

namespace StudentCourse.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student ID is required.")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
