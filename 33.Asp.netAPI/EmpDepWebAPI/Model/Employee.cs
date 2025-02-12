using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmpDepWebAPI.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
