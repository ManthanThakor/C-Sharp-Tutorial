using System;
using System.Threading;

public class ThreadExample
{
    // Method that simulates a task, which prints the thread's name and its priority
    public static void Task(string threadName)
    {
        // Display the thread's name and its assigned priority
        Console.WriteLine($"Thread {threadName} started with priority: {Thread.CurrentThread.Priority}");

        // Simulate some work by running a loop
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{threadName}: {i}");  // Display the thread's name and the current iteration number
            Thread.Sleep(500);  // Simulate work by sleeping for 500 milliseconds
        }

        // Notify that the thread has finished its work
        Console.WriteLine($"Thread {threadName} finished.");
    }

    // Main method where the threads are created, priorities are set, and threads are started
    public static void Main()
    {
        // Create two threads and assign the Task method to be executed by them
        Thread t1 = new Thread(() => Task("Worker-1"));  // Create t1 with Task method and name "Worker-1"
        Thread t2 = new Thread(() => Task("Worker-2"));  // Create t2 with Task method and name "Worker-2"

        // Set the priority for the threads
        t1.Priority = ThreadPriority.Highest;  // Set the priority of t1 to the highest level
        t2.Priority = ThreadPriority.Lowest;   // Set the priority of t2 to the lowest level

        // Start the threads, which will execute the Task method
        t1.Start();  // Start thread t1
        t2.Start();  // Start thread t2

        // Ensure that the main thread waits for t1 and t2 to complete before continuing
        t1.Join();  // Main thread will wait for t1 to finish
        t2.Join();  // Main thread will wait for t2 to finish

        // Notify that the main thread has completed its work
        Console.WriteLine("Main thread finished.");
        Console.ReadLine();
    }
}
