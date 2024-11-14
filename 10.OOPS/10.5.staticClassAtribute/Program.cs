using System;
using SongSpace;

namespace StaticClassAttribute
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("\nStatic Class Attribute\n");

            // Creating instances of Song
            Song song1 = new Song(1 "Artist 1", "3:30");
            Song song2 = new Song(2, "Artist 2", "4:00");

            // Accessing the static song count
            Console.WriteLine($"Total Songs: {Song.SongCount}");

            Console.ReadLine();
        }
    }
}