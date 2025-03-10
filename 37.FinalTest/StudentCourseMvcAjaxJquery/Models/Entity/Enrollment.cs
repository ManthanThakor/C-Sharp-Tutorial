using System.ComponentModel.DataAnnotations;
using StudentCourseMvcAjaxJquery.Models.BEntity;

namespace StudentCourseMvcAjaxJquery.Models.Entity
{
    public class Enrollment : BaseEntity
    {
        [Required(ErrorMessage = "Student ID is required.")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [Required(ErrorMessage = "Enrollment date is required.")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
    }
}
