using System;
using System.Threading;

class Printer
{
    private readonly object lockObject = new object(); // Private lock object

    public void PrintTable()
    {
        lock (lockObject) // Use lockObject instead of this
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(100); // Simulate some work
                Console.WriteLine(i);
            }
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Printer p = new Printer();
        Thread t1 = new Thread(new ThreadStart(p.PrintTable));
        Thread t2 = new Thread(new ThreadStart(p.PrintTable));
        t1.Start();
        t2.Start();
        Console.ReadLine();
    }
}
