using System;
using System.Linq;

namespace ConsoleApp1
{
    public class StudentService
    {
        private readonly SchoolContext _context;

        public StudentService(SchoolContext context)
        {
            _context = context;
        }

        // Create a new student
        public void AddStudent(string firstName, string lastName)
        {
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName
            };

            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine("Student added successfully!");
        }

        // Get all students
        public void GetAllStudents()
        {
            var students = _context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FirstName} {student.LastName}");
            }
        }

        // Update an existing student
        public void UpdateStudent(int id, string firstName, string lastName)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                _context.SaveChanges();
                Console.WriteLine("Student updated successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Delete a student
        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
