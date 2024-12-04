using System;
using System.Threading;

public class ThreadExample
{
    public static void Task(string threadName)
    {
        // Display thread name and priority
        Console.WriteLine($"Thread {threadName} started with priority: {Thread.CurrentThread.Priority}");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{threadName}: {i}");
            Thread.Sleep(500); // Simulate work
        }
        Console.WriteLine($"Thread {threadName} finished.");
    }

    public static void Main()
    {
        // Create threads
        Thread t1 = new Thread(() => Task("Worker-1"));
        Thread t2 = new Thread(() => Task("Worker-2"));

        // Set priorities
        t1.Priority = ThreadPriority.Lowest; // Set highest priority for t1
        t2.Priority = ThreadPriority.Highest;  // Set lowest priority for t2

        // Start threads
        t1.Start();
        t2.Start();

        // Wait for threads to complete
        t1.Join();
        t2.Join();

        Console.WriteLine("Main thread finished.");
        Console.ReadLine();
    }
}
