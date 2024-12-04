using System;
using System.Threading;

class Program
{
    // Shared resource (counter)
    private static int counter = 0;

    // Lock object for synchronization
    private static readonly object lockObject = new object();

    // Method that increments the counter safely
    public static void IncrementCounter()
    {
        // Enter the critical section using Monitor
        Monitor.Enter(lockObject);
        try
        {
            // Critical section
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is incrementing the counter...");
            counter++;
            Console.WriteLine($"Counter: {counter}");
        }
        finally
        {
            // Always release the lock
            Monitor.Exit(lockObject);
        }
    }

    static void Main(string[] args)
    {
        // Create multiple threads to increment the counter
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(IncrementCounter);
        Thread thread3 = new Thread(IncrementCounter);

        // Start the threads
        thread1.Start();
        thread2.Start();
        thread3.Start();

        // Wait for all threads to finish
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("All threads finished execution.");
        Console.ReadLine();
    }
}
