using System;
using MovieSpace;

namespace SetterGetter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Getter and setter example:\n");

            // Creating movie objects using the constructor
            Movie movie1 = new Movie("The Avenger", "dfsj adf", "R");
            Movie movie2 = new Movie("The Sad", "dfasdsj adasdf", "dsadf");

            // Accessing properties to get the values
            Console.WriteLine(movie1.Title); // Using the Title property
            Console.WriteLine(movie1.Rating); // Using the Rating property
            Console.WriteLine(movie2.Rating); // Using the Rating property

            Console.ReadLine();
        }
    }
}
