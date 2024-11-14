using System;

namespace StaticClassExample
{
    // Static class
    public static class MathHelper
    {
        // Static method for adding two numbers
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Static method for multiplying two numbers
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main()
        {
            // Calling static methods directly via the class name
            int sum = MathHelper.Add(3, 4);
            Console.WriteLine($"Sum: {sum}");

            int product = MathHelper.Multiply(3, 4);
            Console.WriteLine($"Product: {product}");

            Console.ReadLine();
        }
    }
}
S