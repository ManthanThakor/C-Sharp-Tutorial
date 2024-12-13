using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.2.stream\\24.2.2.example2\\ConsoleApp1\\birthday.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Hello, this is a sample text file.");
                writer.WriteLine("File handling in C# is simple!");
            }
            Console.WriteLine("File written successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing file: {ex.Message}");
        }

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("\nFile content:");
                Console.WriteLine(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine("This line was added later.");
            }
            Console.WriteLine("\nText appended to the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error appending file: {ex.Message}");
        }


        Console.ReadLine();
    }
}
