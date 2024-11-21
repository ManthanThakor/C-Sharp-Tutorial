using System;

namespace Tuple
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n Tuples  \n");

            // =======================================
            Console.WriteLine(" Tuple with Default Item Names\n");
            // =======================================
            var person = ("person1", "person2", "person3");
            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);
            Console.WriteLine(person.Item3);

            // =======================================
            Console.WriteLine("\n Tuple with Mixed Data Types\n");
            // =======================================
            (int, string, char) student = (1, "Xyz", 'C');
            Console.WriteLine($"Student Id: {student.Item1}");
            Console.WriteLine($"Student Name: {student.Item2}");
            Console.WriteLine($"Student Class: {student.Item3}");

            // =======================================
            Console.WriteLine("\n Tuple with Named Fields\n");
            // =======================================
            (int id, string name, char section) student2 = (2, "ABC", 'B');
            Console.WriteLine($"Student Id: {student2.id}");
            Console.WriteLine($"Student Name: {student2.name}");
            Console.WriteLine($"Student section: {student2.section}");

            // =======================================
            Console.WriteLine("\n Tuple with Explicit Field Names\n");
            // =======================================
            var person3 = (Name: "John", Age: 30, Profession: "Engineer");
            Console.WriteLine($"Name: {person3.Name}, Age: {person3.Age}, Profession: {person3.Profession}");

            // =======================================
            Console.WriteLine("\n ValueTuple Declaration and Usage\n");
            // =======================================
            ValueTuple<int, string, string> person1 = (1, "hi", "How Are You?");
            Console.WriteLine(person1.Item1);
            Console.WriteLine(person1.Item2);
            Console.WriteLine(person1.Item3);

            // =======================================
            Console.WriteLine("\n Tuple Returned by a Method\n");
            // =======================================
            Method method = new Method();
            var result = method.Show("Manthan");
            Console.WriteLine($"Name: {result.Name}, IsValid: {result.IsValid}");

            // =======================================
            Console.WriteLine("\n Tuple for Min and Max in Array\n");
            // =======================================
            var result2 = method.GetMinMax(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Min: {result2.min}, Max: {result2.max}");

            Console.ReadLine();
        }
    }

    public class Method
    {
        // =======================================
        //Console.WriteLine("\n Tuple Returned by a Method\n");
        // =======================================
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
        // =======================================
        //Console.WriteLine("\n Tuple for Min and Max in Array\n");
            // =======================================
        public (int min, int max) GetMinMax(int[] numbers)
        {
            return (numbers.Min(), numbers.Max());
        }
    }
}
