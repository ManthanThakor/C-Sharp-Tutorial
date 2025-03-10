using System.ComponentModel.DataAnnotations;
using StudentCourseMvcAjaxJquery.Models.BEntity;

namespace StudentCourseMvcAjaxJquery.Models.Entity
{
    public class Course : BaseEntity
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
