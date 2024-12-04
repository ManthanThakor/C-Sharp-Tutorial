using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Get and print the current min and max threads in the thread pool
        ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
        ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);

        Console.WriteLine($"Min Worker Threads: {minWorkerThreads}, Max Worker Threads: {maxWorkerThreads}");
        Console.WriteLine($"Min Completion Port Threads: {minCompletionPortThreads}, Max Completion Port Threads: {maxCompletionPortThreads}");

        // Setting custom min and max threads
        ThreadPool.SetMinThreads(2, 2); // Minimum number of threads
        ThreadPool.SetMaxThreads(10, 10); // Maximum number of threads

        // Get and print the updated min and max threads
        ThreadPool.GetMinThreads(out minWorkerThreads, out minCompletionPortThreads);
        ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);

        Console.WriteLine("\nAfter setting new min and max thread values:");
        Console.WriteLine($"Min Worker Threads: {minWorkerThreads}, Max Worker Threads: {maxWorkerThreads}");
        Console.WriteLine($"Min Completion Port Threads: {minCompletionPortThreads}, Max Completion Port Threads: {maxCompletionPortThreads}");

        // Queue work items to the thread pool
        Console.WriteLine("\nMain thread queues work items...");

        // Queue work item for Thread 1
        ThreadPool.QueueUserWorkItem(DoWork, "Task 1");

        // Queue work item for Thread 2
        ThreadPool.QueueUserWorkItem(DoWork, "Task 2");

        // Queue work item for Thread 3
        ThreadPool.QueueUserWorkItem(DoWork, "Task 3");

        // Give the thread pool threads some time to work
        Thread.Sleep(2000); // Main thread sleeps for a short time to let pool threads complete work

        Console.WriteLine("\nMain thread finishes.");
        Console.ReadLine();
    }

    static void DoWork(object state)
    {
        string taskName = (string)state;
        Console.WriteLine($"Thread {taskName} started.");
        Thread.Sleep(1000);  // Simulate some work
        Console.WriteLine($"Thread {taskName} finished.");
    }
}
