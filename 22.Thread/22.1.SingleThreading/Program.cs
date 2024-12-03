using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Task 1 started");
        Task1();
        Console.WriteLine("Task 2 started");
        Task2();
    }

    static void Task1()
    {
        System.Threading.Thread.Sleep(3000); // Simulates a 3-second delay
        Console.WriteLine("Task 1 completed");
    }

    static void Task2()
    {
        System.Threading.Thread.Sleep(3000); // Simulates a 3-second delay
        Console.WriteLine("Task 2 completed");

        Console.ReadLine();
    }
}
