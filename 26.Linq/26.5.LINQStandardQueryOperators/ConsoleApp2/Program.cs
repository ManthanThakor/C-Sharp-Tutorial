
//====================================
//Where
//====================================

//using System;
//using System.Linq;
//using System.Collections.Generic;

//public class Program
//{
//    public static void Main()
//    {
//        // Student collection
//        IList<Student> studentList = new List<Student>() {
//            new Student() { StudentID = 1, StudentName = "John", Age = 13 },
//            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 },
//            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 },
//            new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
//            new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
//        };

//        // Use the Where overload that provides both element and index
//        var filteredResult = studentList.Where((s, i) => i % 2 == 0);

//        // Print the student names from the filtered result
//        foreach (var std in filteredResult)
//        {
//            Console.WriteLine(std.StudentName);
//        }
//    }
//}

//public class Student
//{
//    public int StudentID { get; set; }
//    public string StudentName { get; set; }
//    public int Age { get; set; }
//}

//====================================
//OfType
//====================================

//using System;
//using System.Linq;
//using System.Collections;

//public class Program
//{
//    public static void Main()
//    {
//        IList mixedList = new ArrayList();
//        mixedList.Add(0);
//        mixedList.Add("One");
//        mixedList.Add("Two");
//        mixedList.Add(3);
//        mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

//        var stringResult = from s in mixedList.OfType<string>()
//                           select s;

//        var intResult = from s in mixedList.OfType<int>()
//                        select s;

//        var stdResult = from s in mixedList.OfType<Student>()
//                        select s;

//        foreach (var str in stringResult)
//            Console.WriteLine(str);

//        foreach (var integer in intResult)
//            Console.WriteLine(integer);

//        foreach (var std in stdResult)
//            Console.WriteLine(std.StudentName);

//        Console.ReadLine();
//    }
//}

//public class Student
//{

//    public int StudentID { get; set; }
//    public string StudentName { get; set; }
//    public int Age { get; set; }

//}


//====================================
//orderBy and OrderByDescending
//====================================

//using System;
//using System.Linq;
//using System.Collections.Generic;


//public class Program
//{
//    public static void Main()
//    {
//        // Student collection
//        IList<Student> studentList = new List<Student>() {
//                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
//                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
//                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
//                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
//                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
//            };

//        var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);

//        var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);


//        Console.WriteLine("Ascending Order:");

//        foreach (var std in studentsInAscOrder)
//            Console.WriteLine(std.StudentName);

//        Console.WriteLine("Descending Order:");

//        foreach (var std in studentsInDescOrder)
//            Console.WriteLine(std.StudentName);

//    }

//}

//public class Student
//{

//    public int StudentID { get; set; }
//    public string StudentName { get; set; }
//    public int Age { get; set; }

//}

//====================================
//
//====================================


//====================================
//
//====================================

//====================================
//
//====================================

//====================================
//
//====================================