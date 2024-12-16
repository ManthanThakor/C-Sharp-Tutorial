using System;
using System.IO;
using System.Text;

class BufferedStreamExample
{
    public static void Main()
    {
        string path = "E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.2.stream\\24.2.4.bufferStream\\ConsoleApp1\\TextFile1.txt";
        using (FileStream fs = new FileStream(path, FileMode.Open))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            byte[] buffer = new byte[2000];
            int bytesRead = bs.Read(buffer, 0, buffer.Length);

            string fileContent = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Read {bytesRead} bytes.");
            Console.WriteLine("File Content:");
            Console.WriteLine(fileContent);
        }
        Console.ReadLine();
    }
}
