using System;

namespace Program
{
    class prog
    {
        static void Main(string[] args)
        {
            // 1. For loop: Print numbers from 1 to 5
            Console.WriteLine("For Loop:");
            for(int i = 0; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            // 2. While loop: Print numbers from 6 to 10
            Console.WriteLine("\nWhile Loop:");
            int j = 6;
            while (j <= 10)
            {
                Console.WriteLine(j);
                j++; 
            }

            // 3. Do-While loop: Print numbers from 11 to 15
            Console.WriteLine("\nDo-While Loop:");
            int k = 11;
            do
            {
                Console.WriteLine(k);
                k++; 
            } while (k <= 15);

            // 4. Foreach loop: Iterate through an array and print each element
            Console.WriteLine("\nForeach Loop with Type Conversion:");

            int[] numbers = { 10, 2, 35, 32, 12 };

            string numVal = "";

            foreach (int number in numbers)
            {
                string numberAsString = number.ToString();  // Convert int to string
                double numberAsDouble = (double)number;     // Convert int to double

                numVal += $"Original number (int): {number}\n";
                numVal += $"Converted to string: {numberAsString}\n";
                numVal += $"Converted to double: {numberAsDouble}\n\n"; 
            }

            Console.WriteLine(numVal);

            // Example 2 for each
            Console.WriteLine("\nForeach Example 2;");

            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

        }
    }
}