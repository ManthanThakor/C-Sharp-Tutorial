using System;
using System.Threading;
class Printer
{
    public void PrintTable()
    {
        for (int i = 1; i <= 10; i++)
        {
            Thread.Sleep(100);
            Console.WriteLine(i);
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