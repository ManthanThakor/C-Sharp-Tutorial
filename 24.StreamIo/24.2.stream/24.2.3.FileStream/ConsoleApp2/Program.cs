﻿using System;
using System.IO;

class Program
{
    static void Main()
    {
        string directoryPath = "E:\\manthan\\C-Sharp-Tutorial\\24.StreamIo\\24.2.stream\\24.2.3.FileStream\\ConsoleApp2";
        string filePath = Path.Combine(directoryPath, "example.txt");

        try
        {
            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            byte[] data = System.Text.Encoding.UTF8.GetBytes(@"
_______________________¶¶¶¶___¶¶¶¶¶
_____________________¶¶____¶¶¶____¶¶__¶¶¶
___________________¶¶___¶¶¶____¶¶¶¶¶¶¶___¶¶
_________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
______________¶¶¶¶¶__¶__________________________¶¶
___________¶¶¶¶__¶¶__¶___________________________¶
_________¶¶¶_¶¶__¶__¶¶¶__________________________¶
______¶¶¶_¶¶_¶¶¶_¶_¶¶_¶¶_________¶_______________¶
_____¶_¶¶__¶_¶_¶¶¶¶_¶¶¶__________¶¶______________¶
___¶¶¶_¶¶¶¶¶_¶¶¶¶¶¶_¶¶¶_________¶¶¶______________¶
_¶¶__¶¶¶¶¶¶¶¶_¶¶_¶¶____________¶¶¶¶¶_____________¶
¶_¶¶__¶__¶¶¶¶____¶¶___________¶¶¶¶¶¶¶____________¶
¶__¶¶¶¶¶¶¶¶¶¶____¶¶__________¶¶¶¶¶¶¶¶¶¶__________¶
_¶¶¶_¶_¶¶___¶¶___¶¶________¶¶¶¶¶¶¶¶¶¶¶¶¶_________¶
__¶¶_¶¶_¶___¶¶___¶¶______¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_______¶
___¶¶____¶___¶___¶¶____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_____¶
____¶¶___¶¶__¶¶__¶¶___¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶___¶
_____¶¶___¶__¶¶__¶¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶__¶
______¶¶___¶__¶__¶¶_¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_¶
_______¶¶__¶¶_¶__¶¶_¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_¶
________¶¶__¶_¶¶_¶¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_¶
_________¶¶__¶_¶_¶¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶__¶
__________¶¶_¶¶¶_¶¶___¶¶¶¶¶¶¶¶¶__¶¶__¶¶¶¶¶¶¶¶¶___¶
____________¶_¶¶_¶¶_____¶¶¶¶¶____¶¶____¶¶¶¶¶_____¶
_____________¶_¶¶¶¶___________¶¶¶¶¶¶¶¶___________¶
______________¶¶¶¶¶__________¶¶¶¶¶¶¶¶¶¶______¶¶__¶
_______________¶¶¶____________¶¶¶¶¶¶¶¶_______¶¶¶_¶
________________¶¶__________________________¶¶_¶_¶
_________________¶¶__________________________¶¶__¶
_________________¶¶__________________________¶¶¶_¶
__________________¶¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
__________________¶¶¶¶¶¶¶¶¶¶¶¶
_____________________¶¶¶¶¶¶
");

            // Writing with FileStream
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
                Console.WriteLine("Data written using FileStream.");
            }

            // Reading with FileStream
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[data.Length];
                fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine("Read from FileStream: " + System.Text.Encoding.UTF8.GetString(buffer));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.ReadLine();
    }
}