using System.ComponentModel.DataAnnotations;

namespace EmpDepWebAPI.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
