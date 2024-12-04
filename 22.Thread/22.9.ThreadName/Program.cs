using System;
using System.Threading;

public class ThreadExample
{
    public static void Task()
    {
        // Display the thread name during execution
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} is starting.");
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {i}");
            Thread.Sleep(500); // Simulating some work
        }
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} is finished.");
    }

    public static void Main()
    {
        // Create threads
        Thread t1 = new Thread(Task);
        Thread t2 = new Thread(Task);

        // Assign names to threads
        t1.Name = "Worker-1";
        t2.Name = "Worker-2";

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
