using System.ComponentModel.DataAnnotations;
using StudentCourseMvcAjaxJquery.Models.BEntity;

namespace StudentCourseMvcAjaxJquery.Models.Entity
{
    public class Student : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Address cannot be more than  200 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
