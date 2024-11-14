using System;

namespace StaticExample
{
    public class Calculator
    {
        // Static method
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Instance method
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main()
        {
            // Calling the static method directly via the class name
            int sum = Calculator.Add(3, 4);
            Console.WriteLine($"Sum: {sum}");

            // Creating an instance to call the instance method
            Calculator calc = new Calculator();
            int product = calc.Multiply(3, 4);
            Console.WriteLine($"Product: {product}");

            Console.ReadLine();
        }
    }
}
