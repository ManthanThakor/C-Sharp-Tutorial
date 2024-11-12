using System;

namespace program
{
    class Pro
    {
    static void Main(string[] args)
        {
            // 1. Declaring and initializing an array

            int[] numb = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            // 2. Accessing elements
            Console.WriteLine("Array elements:");
            Console.WriteLine(numb[0]);
            Console.WriteLine(numb[1]);
            Console.WriteLine(numb[2]);
            Console.WriteLine(numb[3]);

            // 3. Modifying an element

            numb[3] = 1000;
            Console.WriteLine($"Modified third element: {numb[3]}");

            // 4. Iterating through the array using a loop
            Console.WriteLine("\nIterating through the array:");
            for(int i =0; i < numb.Length; i++)
            {
                Console.WriteLine(numb[i]);
            }

            // 5. Iterating through the array using a loop AND condition
            Console.WriteLine("\nIterating through the array + conditon:");

            int count = 0;

            // Count the elements that are not equal to 1
            for (int i = 0; i < numb.Length; i++)
            {
                if (numb[i] != 1)
                {
                    count++;
                }
            }

            // Create an empty array with the size based on the count
            int[] newArr = new int[count];
            int index = 0;
            // Populate the new array with elements that are not equal to 1
            foreach (int num in numb)
            {
                if (num != 1)
                {
                    newArr[index++] = num;
                }
            }

            // Display the new array
            Console.WriteLine("New Array (without 1's):");
            foreach (int num in newArr)
            {
                Console.WriteLine(num);
            }

            // 5. Using foreach loop to iterate over the array
            Console.WriteLine("\nUsing foreach loop:");
            foreach (int number in numb)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }

}