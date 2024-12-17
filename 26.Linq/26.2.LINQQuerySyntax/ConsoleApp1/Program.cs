//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//        var evenNumbers = from num in numbers
//                          where num % 2 == 0
//                          select num;

//        // Display the result
//        Console.WriteLine("Even numbers:");
//        foreach (var num in evenNumbers)
//        {
//            Console.WriteLine(num);
//        }

//        IList<string> stringList = new List<string>() {
//            "C# Tutorials",
//            "VB.NET Tutorials",
//            "Learn C++",
//            "MVC Tutorials" ,
//            "Java"
//        };
//        var result = from s in stringList
//                     where s.Contains("Tutorials")
//                     select s;

//        foreach (var str in result)
//        {
//            Console.WriteLine(str);
//        }
//        Console.ReadLine();
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuerySyntax
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Student collection Example");

            // Student collection
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 },
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 },
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            // LINQ Query Syntax to find teenage students
            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;

            // Display the results
            Console.WriteLine("Teenage Students:");
            foreach (Student std in teenAgerStudent)
            {
                Console.WriteLine("Name: " + std.StudentName + ", Id: " + std.StudentID + ", Age:" + std.Age);
            }

            Console.ReadLine();
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
