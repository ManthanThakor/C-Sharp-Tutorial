using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Multi Threading");

        Thread thread1 = new Thread(Task1);
        Thread thread2 = new Thread(Task2);


        thread1.Start(); // Start Task1 on a new thread
        thread2.Start(); // Start Task2 on a new thread

        thread1.Join(); // Wait for Task1 to complete
        thread2.Join(); // Wait for Task2 to complete

        Console.WriteLine("Both tasks completed");
        Console.ReadLine();
    }

    static void Task1()
    {
        Thread.Sleep(3000); // Simulates a 3-second delay
        Console.WriteLine("Task 1 completed");
    }

    static void Task2()
    {
        Thread.Sleep(3000); // Simulates a 3-second delay
        Console.WriteLine("Task 2 completed");

       
    }
}
