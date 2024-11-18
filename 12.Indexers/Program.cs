using System;

namespace IndexerExample
{
    public class Fruits
    {
        private string[] name = new string[10];

        // Indexer declaration
        public string this[int index]
        {
            get
            {
                return name[index];
            }
            set
            {
                name[index] = value;
            }
        }
    }

    public class ReadOnlyCollection
    {
        private string[] _data = new string[3] { "Alpha", "Beta", "Gamma" };

        public string this[int index]
        {
            get => (index >= 0 && index < _data.Length) ? _data[index] : throw new IndexOutOfRangeException("Invalid index.");
        }
    }

    public class BookCollection
    {
        private int[] _pages = new int[5];  // Fixed-size integer array to store the number of pages in books
        private double[] _ratings = new double[5]; // Fixed-size array to store the ratings of books

        // Indexer for accessing elements of _pages array
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < _pages.Length)
                {
                    return _pages[index];
                }
                throw new IndexOutOfRangeException("Index out of range.");
            }
            set
            {
                if (index >= 0 && index < _pages.Length)
                {
                    _pages[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
            }
        }

        // Overloaded indexer for accessing elements of _ratings array (using a string parameter)
        public double this[string ratingIndex]
        {
            get
            {
                int index = Array.IndexOf(new string[] { "First", "Second", "Third", "Fourth", "Fifth" }, ratingIndex);
                if (index >= 0 && index < _ratings.Length)
                {
                    return _ratings[index];
                }
                throw new IndexOutOfRangeException("Invalid rating index.");
            }
            set
            {
                int index = Array.IndexOf(new string[] { "First", "Second", "Third", "Fourth", "Fifth" }, ratingIndex);
                if (index >= 0 && index < _ratings.Length)
                {
                    _ratings[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid rating index.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Indexer Example \n");

            // Fruits Example
            Fruits fruits = new Fruits();
            fruits[0] = "Apple";
            fruits[1] = "Mango";
            fruits[2] = "Kiwi";
            fruits[3] = "Orange";

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(fruits[i]);
            }

            // ReadOnlyCollection Example
            Console.WriteLine("\n ReadOnlyCollection Example \n");

            ReadOnlyCollection collec = new ReadOnlyCollection();

            Console.WriteLine(collec[0]);
            Console.WriteLine(collec[1]);
            Console.WriteLine(collec[2]);

            // BookCollection Example
            Console.WriteLine("\n Indexer Overloading Example \n");

            BookCollection books = new BookCollection();

            books[0] = 300;  
            books[1] = 250;  

            books["First"] = 4.5;
            books["Second"] = 3.8;

            Console.WriteLine("Pages in Book 1: " + books[0]); 
            Console.WriteLine("Pages in Book 2: " + books[1]); 

            Console.WriteLine("Rating of First Book: " + books["First"]); 
            Console.WriteLine("Rating of Second Book: " + books["Second"]); 


            Console.ReadLine();
        }
    }
}
