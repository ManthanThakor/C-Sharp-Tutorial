using System;
using StudentSpace;

namespace MainProgram 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Object Methods");

            // student object
            Student student1 = new Student("Toni", "Class 10", 3.5);
            Student student2 = new Student("chitaa", "Class 10", 2);
            Student student3 = new Student("con", "Class 10", 3.9);

            Console.WriteLine(student1.hasHonor());
            Console.WriteLine(student2.hasHonor());
            Console.WriteLine(student3.hasHonor());
            Console.ReadLine();
        }
    }
}
