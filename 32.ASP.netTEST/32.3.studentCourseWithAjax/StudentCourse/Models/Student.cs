using System;
using System.ComponentModel.DataAnnotations;

namespace StudentCourse.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(30, ErrorMessage = "Email cannot be longer than 30 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
