using StudentCourseMvcAjaxJquery.Models.BEntity;

namespace StudentCourseMvcAjaxJquery.Models.Entity
{
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
