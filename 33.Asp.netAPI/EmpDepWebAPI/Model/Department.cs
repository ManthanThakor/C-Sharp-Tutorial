using System.ComponentModel.DataAnnotations;

namespace EmpDepWebAPI.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
