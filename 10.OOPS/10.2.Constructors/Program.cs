using System;
using BookSpace;

namespace Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Constructor Tutorial");

            // object of class book

            var book = new Book("C# Fundamentals", "A guide to learning C# basics", "Introduction to C#", "John Doe", 250);
            book.DisplayInfo();

            Console.ReadLine();
        }
    }
}