////using System;
////using System.Collections.Generic;
////using System.Linq;

////class Program
////{
////    static void Main()
////    {
////        // Sample data: List of integers
////        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

////        // LINQ method syntax to find even numbers
////        var evenNumbers = numbers.Where(num => num % 2 == 0);

////        // Display the result
////        Console.WriteLine("Even numbers:");
////        foreach (var num in evenNumbers)
////        {
////            Console.WriteLine(num);
////        }
////        Console.ReadLine();
////    }
////}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//public class Program
//{
//    public static void Main()
//    {
//        IList<string> list = new List<string>()
//        {
//            "Tutorial c#",
//            "Tutorial XYZ",
//            "VB.NET Tutorials",
//            "Learn C++",
//            "MVC Tutorials",
//            "Java"
//        };

//        // Use LINQ to filter the strings containing "Tutorial"
//        var result = list.Where(s => s.Contains("Tutorial"));

//        // Display the results
//        foreach (var str in result)
//        {
//            Console.WriteLine(str);
//        }
//        Console.ReadLine();
//    }
//}


using System;
using System.Linq;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

        // LINQ Query Method to find out teenager students
        var teenAgerStudent = studentList.Where(s => s.Age > 12 && s.Age < 20);

        Console.WriteLine("Teen age Students:");

        foreach (Student std in teenAgerStudent)
        {
            Console.WriteLine(std.StudentName);
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