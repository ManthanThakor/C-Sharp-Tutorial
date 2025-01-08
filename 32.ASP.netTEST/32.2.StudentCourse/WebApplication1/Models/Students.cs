namespace WebApplication1.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
