using System;
using System.IO;

namespace Stream
{
    class Program
    {
        static void Main(String[] args)
        {
            string FilePath = @"E:\manthan\C-Sharp-Tutorial\24.StreamIo\24.2.stream\24.2.1.example1\dog.txt";
            string data;

            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }
            Console.WriteLine(data);

            Console.ReadKey();

        }
    }
}
