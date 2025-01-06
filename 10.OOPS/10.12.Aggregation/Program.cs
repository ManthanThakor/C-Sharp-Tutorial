using System;

namespace AggregationExample
{
    // Book class
    public class Book
    {
        public string Title { get; set; }

        public Book(string title)
        {
            Title = title;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title}");
        }
    }

    // Library class (aggregating a single Book object)
    public class Library
    {
        public string Name { get; set; }
        public Book Book { get; set; }

        public Library(string name, Book book)
        {
            Name = name;
            Book = book;
        }
        
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library: {Name}");
            Console.WriteLine($"Book Name: {Book}");

            Book.DisplayInfo();  // Display info of the aggregated Book
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a Book object
            Book book1 = new Book("C# Programming");

            // Create a Library object and aggregate the Book object
            Library library = new Library("City Library", book1);

            // Display information about the Library and its Book
            library.DisplayLibraryInfo();

            // Even if the Library object is deleted, the Book object still exists independently
            Console.WriteLine("\nThe Book object can still exist independently:");
            book1.DisplayInfo();

            Console.ReadLine();
        }
    }
}

