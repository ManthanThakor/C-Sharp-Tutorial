using System;
using MovieSpace;

namespace SetterGetter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Getter and setter example:\n");

            Movie movie1 = new Movie("The Avanger","dfsj adf","R");
            Movie movie2 = new Movie("The sad", "dfasdsj adasdf", "dsadf");
            Console.WriteLine(movie1.title);
            Console.WriteLine(movie1.Rating);
            Console.WriteLine(movie2.Rating);

            Console.ReadLine();
        }
    }
}