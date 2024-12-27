
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentEmp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string ImageFilePath { get; set; }
        [NotMapped]
        public IFormFile ImageData { get; set; }
    }
}

