using StudentCourseMvcAjaxJquery.Models.BEntity;

namespace StudentCourseMvcAjaxJquery.Models.Entity
{
    public class Course : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
