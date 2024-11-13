using System;

namespace BookSpace
{
    class Book
    {
        public string Name;
        public string Description;
        public string Title;
        public string Author;
        public int Pages;

        // Created a Book class constructor with multiple parameters

        public Book(string name, string description, string title, string author, int pages)
        {
            Name = name;
            Description = description;
            Title = title;
            Author = author;
            Pages = pages;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Book Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Pages: {Pages}");
        }
    }
}