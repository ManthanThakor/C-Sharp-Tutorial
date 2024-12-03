using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create a new thread
        Thread myThread = new Thread(new ThreadStart(MyThreadMethod));

        // Set thread properties
        myThread.Name = "Worker Thread";    // Set thread name
        myThread.IsBackground = true;       // Set as background thread
        myThread.Priority = ThreadPriority.AboveNormal; // Set thread priority

        // Start the thread
        myThread.Start();
        Console.ReadLine();
    }

    static void MyThreadMethod()
    {
        Console.WriteLine("Thread is running...");
        Thread.Sleep(1000);  // Simulate some work
        Console.WriteLine("Thread completed.");
    }
}
