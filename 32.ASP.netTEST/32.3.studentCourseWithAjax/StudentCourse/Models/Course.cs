using System.ComponentModel.DataAnnotations;

namespace StudentCourse.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public string Title { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
