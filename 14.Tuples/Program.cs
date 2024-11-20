using System;

namespace Tuple
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n Tuples  \n");

            // =======================================
            Console.WriteLine(" Tuple Example 1\n");
            // =======================================
            var person = ("person1", "person2", "person3");
            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);
            Console.WriteLine(person.Item3);

            // =======================================
            Console.WriteLine("\n Tuple Example 2\n");
            // =======================================
            (int, string, char) student = (1, "Xyz", 'C');
            Console.WriteLine($"Student Id: {student.Item1}");
            Console.WriteLine($"Student Name: {student.Item2}");
            Console.WriteLine($"Student Class: {student.Item3}");

            // =======================================
            Console.WriteLine("\n Tuple Example 3\n");
            // =======================================
            (int id, string name, char section) student2 = (2, "ABC", 'B');
            Console.WriteLine($"Student Id: {student2.id}");
            Console.WriteLine($"Student Name: {student2.name}");
            Console.WriteLine($"Student section: {student2.section}");

            // =======================================
            Console.WriteLine("\n Tuple Example 4\n");
            // =======================================
            var person3 = (Name: "John", Age: 30, Profession: "Engineer");
            Console.WriteLine($"Name: {person3.Name}, Age: {person3.Age}, Profession: {person3.Profession}");

            // =======================================
            Console.WriteLine("\n Tuple Example 5\n");
            // =======================================
            ValueTuple<int, string, string> person1 = (1, "hi", "How Are You?");
            Console.WriteLine(person1.Item1);
            Console.WriteLine(person1.Item2);
            Console.WriteLine(person1.Item3);
           

            // =======================================
            Console.WriteLine("\n Tuple Example 6\n");
            // =======================================
            
            Method method = new Method();

            var Rock = method.Show("Manthan");
            if (Rock.IsValid)
            {
                Console.WriteLine(Rock.Name);
                return ();
            }
            else
            {
                Console.WriteLine("Invalid Name");

            }

            Console.ReadLine();

        }
    }

    public class Method
    {
        public (string Name, bool IsValid) Show(string name)
        {
            if (name == "Manthan")
            {
                return ($"Hello {name}", true); 
            }
            else
            {
                return (name, false); 
            }
        }
    }
}
