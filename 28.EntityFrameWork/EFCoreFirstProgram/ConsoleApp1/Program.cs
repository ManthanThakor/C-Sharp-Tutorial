using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var studentService = new StudentService(context);

                studentService.AddStudent("John", "Doe");
                studentService.AddStudent("Jane", "Smith");

                Console.WriteLine("\nAll students:");
                studentService.GetAllStudents();

                studentService.UpdateStudent(1, "Johnny", "Doe");

                Console.WriteLine("\nStudents after update:");
                studentService.GetAllStudents();

                studentService.DeleteStudent(2);

                Console.WriteLine("\nStudents after deletion:");
                studentService.GetAllStudents();
            }
        }
    }

}