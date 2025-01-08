namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
