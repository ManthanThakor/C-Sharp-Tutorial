//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        // Sample data: List of integers
//        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//        // LINQ method syntax to find even numbers
//        var evenNumbers = numbers.Where(num => num % 2 == 0);

//        // Display the result
//        Console.WriteLine("Even numbers:");
//        foreach (var num in evenNumbers)
//        {
//            Console.WriteLine(num);
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
        IList<string> list = new List<string>()
        {
            "Tutorial c#",
            "Tutorial XYZ",
            "VB.NET Tutorials",
            "Learn C++",
            "MVC Tutorials",
            "Java"
        };

        // Use LINQ to filter the strings containing "Tutorial"
        var result = list.Where(s => s.Contains("Tutorial"));

        // Display the results
        foreach (var str in result)
        {
            Console.WriteLine(str);
        }
        Console.ReadLine();
    }
}
