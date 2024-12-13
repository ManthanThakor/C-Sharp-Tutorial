using System;
using System.IO;
 
namespace DogArt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.1.ReadAndWrite\\dog.txt"))
            {
                string dogString = File.ReadAllText("E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.1.ReadAndWrite\\dog.txt");
                Console.WriteLine(dogString);
            }

            if (File.Exists("E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.1.ReadAndWrite\\cat.txt"))
            {
                string catString = @"  
  /\_/\  
 ( o.o )   
  > ^ <  ";
                File.WriteAllText("E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.1.ReadAndWrite\\cat.txt", catString);
              
            }

            // Reading text from a file
            using (StreamReader reader = new StreamReader("E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.1.ReadAndWrite\\cat.txt"))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }

            Console.ReadLine(); // Fixed capitalization
        }
    }
}
