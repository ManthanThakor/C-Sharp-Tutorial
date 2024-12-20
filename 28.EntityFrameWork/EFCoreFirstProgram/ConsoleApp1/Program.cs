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
                context.Database.Migrate();

                // Check if any students are in the database
                var students = context.Students.ToList();

                if (students.Any())
                {
                    Console.WriteLine("Students found in the database:");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Id} - {student.FirstName} {student.LastName}");
                    }
                }
                else
                {
                    Console.WriteLine("No students found in the database.");

                    // Add a student if none exist
                    var student = new Student
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    };
                    context.Students.Add(student);
                    context.SaveChanges();

                    Console.WriteLine("Student added to the database!");
                }
            }

            Console.WriteLine("Database migration completed!");
        }
    }
}
